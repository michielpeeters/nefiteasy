namespace NefitEasy.Models.Internal
{
    using Matrix.Xmpp.Client;

    internal class NefitEasyPutMessage : Message
    {
        public const string MARKER = "{marker}";

        public override string ToString(bool indented)
        {
            return base.ToString(false).Replace(MARKER, "&#13;\n");
        }
    }
}