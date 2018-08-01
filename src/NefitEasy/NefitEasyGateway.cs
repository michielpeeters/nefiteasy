namespace NefitEasy
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Authentication;
    using Enumerations;
    using Matrix;
    using Request;
    using Codecs;

    public class NefitEasyGateway : INefitEasyGateway
    {
        public event EventHandler<ClientStatus> OnClientStatusChanged;

        public XmppClient Client { get; private set; }
        public NefitEasyCredentials Credentials { get; }
        public ClientStatus ClientStatus { get; private set; }
        
        private readonly IEncryptingCodec _rijndael;

        public NefitEasyGateway(NefitEasyCredentials credentials)
        {
            Credentials = credentials;
            _rijndael = new RijndaelEncryptingCodec(new SigningKeyGenerator(Credentials));
        }

        public TResult Get<TResult>(string endpoint)
        {
            return GetAsync<TResult>(endpoint)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<TResult> GetAsync<TResult>(string endpoint, CancellationToken token = default(CancellationToken))
        {
            return await new Get<TResult>(this, _rijndael)
                .ExecuteAsync(endpoint, token)
                .ConfigureAwait(false);
        }

        public bool Put(string endpoint, string data)
        {
            return PutAsync(endpoint, data)
                .GetAwaiter()
                .GetResult();
        }

        public async Task<bool> PutAsync(string endpoint, string data, CancellationToken token = default(CancellationToken))
        {
            return await new Put(this, _rijndael)
                .ExecuteAsync(endpoint, data, token)
                .ConfigureAwait(false);
        }

        public void Connect()
        {
            ConnectAsync()
                .GetAwaiter()
                .GetResult();
        }

        public async Task ConnectAsync(CancellationToken token = default(CancellationToken))
        {
            if (Client != null)
                await DisconnectAsync(token).ConfigureAwait(false);

            SetClientStatus(ClientStatus.Connecting);

            var authenticationResult = await new Authenticator().AuthenticateAsync(Credentials, token).ConfigureAwait(false);
            await HandleAuthenticationResult(authenticationResult, token).ConfigureAwait(false);
        }

        private async Task HandleAuthenticationResult(AuthenticationResult authenticationResult, CancellationToken token)
        {
            if (authenticationResult.IsAuthenticated)
            {
                Client = authenticationResult.Client;
                Credentials.JabberId = authenticationResult.JabberId;

                await ExecuteAuthenticationTest(token).ConfigureAwait(false);
            }
            else
            {
                SetClientStatus(ClientStatus.InvalidCredentials);
            }
        }

        private async Task ExecuteAuthenticationTest(CancellationToken token)
        {
            SetClientStatus(ClientStatus.AuthenticationTest);
            var serialNumber = await GetAsync<string>(NefitEndpointConstants.UUID_ENDPOINT_PATH, token).ConfigureAwait(false);

            if (serialNumber == Credentials.SerialNumber)
                SetClientStatus(ClientStatus.Connected);
            else
                await DisconnectAsync(token).ConfigureAwait(false);
        }

        public void Disconnect()
        {
            DisconnectAsync()
                .GetAwaiter()
                .GetResult();
        }

        public async Task DisconnectAsync(CancellationToken token = default(CancellationToken))
        {
            SetClientStatus(ClientStatus.Disconnecting);

            await Client.DisconnectAsync(true, 30000).ConfigureAwait(false);
            Client = null;

            SetClientStatus(ClientStatus.Disconnected);
        }

        private void SetClientStatus(ClientStatus status)
        {
            ClientStatus = status;
            OnClientStatusChanged?.Invoke(this, status);
        }
    }
}