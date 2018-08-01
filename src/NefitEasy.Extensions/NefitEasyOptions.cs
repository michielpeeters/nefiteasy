namespace NefitEasy.Extensions
{
    public class NefitEasyOptions
    {
        public bool IsSingletonClient { get; set; }

        public bool AutoConnect { get; set; }

        public NefitEasyCredentials Credentials { get; set; }
    }
}