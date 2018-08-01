namespace NefitEasy.Request
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Matrix.Xml;
    using Matrix.Xmpp;
    using Matrix.Xmpp.Client;
    using Microsoft.Extensions.Logging;
    using Models.Internal;
    using Codecs;

    public class Put
    {
        private readonly INefitEasyGateway _gateway;
        private readonly IEncryptingCodec _codec;

        private readonly ILogger _log = new LoggerFactory().CreateLogger(typeof(Put));

        private bool _response;
        private IDisposable _subscription;

        public Put(INefitEasyGateway gateway, IEncryptingCodec codec)
        {
            _gateway = gateway;
            _codec = codec;
        }

        public bool Execute(string endpoint, string data)
        {
            return ExecuteAsync(endpoint, data).GetAwaiter().GetResult();
        }

        public async Task<bool> ExecuteAsync(string endpoint, string data, CancellationToken token = default(CancellationToken))
        {
            if (!CanExecute(endpoint, data))
                return false;

            SubscribeForResponse();
            await SendRequestAsync(endpoint, _codec.Encrypt(data), token);
            UnsubscribeForResponse();

            return _response;
        }

        private bool CanExecute(string endpoint, string data)
        {
            return !string.IsNullOrWhiteSpace(endpoint) 
                   && !string.IsNullOrWhiteSpace(data) 
                   && _gateway.Client != null;
        }

        private async Task SendRequestAsync(string endpoint, string data, CancellationToken token = default(CancellationToken))
        {
            await _gateway.Client.SendAsync<Message>(CreatePutMessage(endpoint, data), 30000, token).ConfigureAwait(false);
        }

        private Message CreatePutMessage(string endpoint, string data)
        {
            return new NefitEasyPutMessage {
                Body = CreateMessageBody(endpoint, data),
                From = _gateway.Credentials.JabberId,
                To = $"{NefitConnectionConstants.RCC_GATEWAY_PREFIX}{_gateway.Credentials.SerialNumber}@{NefitConnectionConstants.HOST}",
            };
        }

        private static string CreateMessageBody(string endpoint, string data)
        {
            var parts = new[] {
                $"PUT {endpoint} HTTP/1.1",
                "Content-Type: application/json",
                $"Content-Length: {data.Length}",
                "User-Agent: NefitEasy",
                "",
                data
            };

            return string.Join(NefitEasyPutMessage.MARKER, parts);
        }

        private void SubscribeForResponse()
        {
            _subscription = _gateway.Client.XmppXElementStreamObserver
                .Where(element => element.OfType<Message>() && element.Cast<Message>().Type == MessageType.Chat)
                .Subscribe(OnStreamResponse());
        }

        private void UnsubscribeForResponse()
        {
            _subscription.Dispose();
        }

        private Action<XmppXElement> OnStreamResponse()
        {
            return element =>
            {
                try
                {
                    var response = new HttpResponse(element.Cast<Message>().Body);
                    _response = new[] { HttpStatusCode.OK, HttpStatusCode.NoContent }.Any(code => response.HttpResponseCode == (int) code);
                }
                catch (Exception ex)
                {
                    _log.LogError(1001, ex, ex.Message);
                    _response = false;
                }
            };
        }
    }
}