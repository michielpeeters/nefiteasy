namespace NefitEasy.Authentication
{
    using Matrix;

    public class AuthenticationResult
    {
        public XmppClient Client { get; set; }

        public string JabberId { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}