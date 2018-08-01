namespace NefitEasy
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Enumerations;
    using Matrix;

    public interface INefitEasyGateway
    {
        event EventHandler<ClientStatus> OnClientStatusChanged;

        XmppClient Client { get; }
        NefitEasyCredentials Credentials { get; }
        ClientStatus ClientStatus { get; }

        TResult Get<TResult>(string endpoint);
        Task<TResult> GetAsync<TResult>(string endpoint, CancellationToken token = default(CancellationToken));
        bool Put(string endpoint, string data);
        Task<bool> PutAsync(string endpoint, string data, CancellationToken token = default(CancellationToken));
        void Connect();
        Task ConnectAsync(CancellationToken token = default(CancellationToken));
        void Disconnect();
        Task DisconnectAsync(CancellationToken token = default(CancellationToken));
    }
}