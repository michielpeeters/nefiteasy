namespace NefitEasy.Parsing
{
    public class NefitEasyBoolParser
    {
        public bool Execute(string status) => !string.IsNullOrWhiteSpace(status) && status == "on" || status == "true";
    }
}