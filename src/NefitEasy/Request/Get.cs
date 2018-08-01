namespace NefitEasy.Request
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Matrix.Xml;
    using Matrix.Xmpp;
    using Matrix.Xmpp.Client;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Codecs;

    public class Get<TResult>
    {
        private readonly INefitEasyGateway _gateway;
        private readonly IEncryptingCodec _codec;

        private readonly ILogger _log = new LoggerFactory().CreateLogger(typeof(Get<TResult>));

        private JsonResponse<TResult> _response;
        private IDisposable _subscription;

        public Get(INefitEasyGateway gateway, IEncryptingCodec codec)
        {
            _gateway = gateway;
            _codec = codec;
        }

        public TResult Execute(string endpoint)
        {
            return ExecuteAsync(endpoint).GetAwaiter().GetResult();
        }

        public async Task<TResult> ExecuteAsync(string endpoint, CancellationToken token = default(CancellationToken))
        {
            if (!CanExecute(endpoint))
                return default(TResult);

            SubscribeForResponse();
            await SendRequestAsync(endpoint, token);
            UnsubscribeForResponse();

            return _response != null ? _response.Value : default(TResult);
        }

        private bool CanExecute(string endpoint)
        {
            return !string.IsNullOrWhiteSpace(endpoint) && _gateway.Client != null;
        }

        private async Task SendRequestAsync(string endpoint, CancellationToken token = default(CancellationToken))
        {
            await _gateway.Client.SendAsync<Message>(CreateGetMessage(endpoint), 30000, token).ConfigureAwait(false);
        }

        private Message CreateGetMessage(string endpoint)
        {
            return new Message {
                Body = $"GET {endpoint} HTTP/1.1\n User-Agent: NefitEasy",
                From = _gateway.Credentials.JabberId,
                To = $"{NefitConnectionConstants.RCC_GATEWAY_PREFIX}{_gateway.Credentials.SerialNumber}@{NefitConnectionConstants.HOST}"
            };
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
                    var data = _codec.Decrypt(response.Payload);

                    _response = JsonConvert.DeserializeObject<JsonResponse<TResult>>(data);
                }
                catch (Exception ex)
                {
                    _log.LogError(1000, ex, ex.Message);
                    _response = null;
                }
            };
        }
    }
}