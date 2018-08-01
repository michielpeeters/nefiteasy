namespace NefitEasy.Extensions
{
    public class NefitEasyClientFactory
    {
        private readonly NefitEasyOptions _options;

        public NefitEasyClientFactory(NefitEasyOptions options)
        {
            _options = options;
        }

        public INefitEasyClient Produce()
        {
            var client = new NefitEasyClient(_options.Credentials);

            if (_options.AutoConnect)
                client.ConnectAsync().GetAwaiter().GetResult();

            return client;
        }
    }
}