namespace NefitEasy.Authentication
{
    using System;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Matrix;
    using Matrix.Extensions.Client.Presence;
    using Matrix.Extensions.Client.Roster;
    using Matrix.Xml;
    using Matrix.Xmpp;
    using Matrix.Xmpp.Bind;
    using Matrix.Xmpp.Client;
    using Matrix.Xmpp.Sasl;

    public class Authenticator
    {
        private XmppClient _client;
        private string _jabberId;
        private bool _isAuthenticated = true;

        public async Task<AuthenticationResult> AuthenticateAsync(NefitEasyCredentials credentials, CancellationToken token = default(CancellationToken))
        {
            InitializeXmppClient(credentials);

            SubscribeForNotAuthorized();
            SubscribeForJabberId();

            await _client.ConnectAsync(token).ConfigureAwait(false);

            var result = new AuthenticationResult {
                Client = _client,
                JabberId = _jabberId,
                IsAuthenticated = _isAuthenticated && !string.IsNullOrWhiteSpace(_jabberId)
            };

            if (result.IsAuthenticated)
                await IdentifyToJabberServer(token).ConfigureAwait(false);

            return result;
        }

        private async Task IdentifyToJabberServer(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _client.RequestRosterAsync(30000, cancellationToken).ConfigureAwait(false);
            await _client.SendPresenceAsync(Show.Chat).ConfigureAwait(false);
        }

        private void InitializeXmppClient(NefitEasyCredentials credentials)
        {
            _client = new XmppClient() {
                Username = $"{NefitConnectionConstants.RCC_CONTACT_PREFIX}{credentials.SerialNumber}",
                Password = $"{NefitConnectionConstants.ACCESS_KEY_PREFIX}{credentials.AccessKey}",
                XmppDomain = NefitConnectionConstants.HOST
            };
        }

        private void SubscribeForNotAuthorized()
        {
            _client.XmppXElementStreamObserver
                .Where(element => element.OfType<Failure>() && element.Cast<Failure>().Condition == FailureCondition.NotAuthorized)
                .Subscribe(element => { _isAuthenticated = false; });
        }

        private void SubscribeForJabberId()
        {
            _client.XmppXElementStreamObserver
                .Where(element => element.OfType<Iq>() && element.Cast<Iq>().Type == IqType.Result && element.Cast<Iq>().Query.OfType<Bind>())
                .Subscribe(element => { _jabberId = element.Value; });
        }
    }
}