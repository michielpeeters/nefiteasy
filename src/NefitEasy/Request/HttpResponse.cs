namespace NefitEasy.Request
{
    public class HttpResponse
    {
        public int HttpResponseCode { get; private set; }

        public string[] HeaderData { get; private set; }

        public string Payload { get; private set; }

        public HttpResponse(string httpResponseString)
        {
            var httpResoonseLines = httpResponseString.Split('\n');

            DetermineHttpResponseCode(httpResoonseLines);
            DetermineHeaderData(httpResoonseLines);
            DeterminePayload(httpResoonseLines);
        }

        private void DeterminePayload(string[] httpResoonseLines)
        {
            Payload = httpResoonseLines[httpResoonseLines.Length - 1];
        }

        private void DetermineHeaderData(string[] httpResponseLines)
        {
            HeaderData = new string[httpResponseLines.Length - 4];
            for (var i = 1; i < httpResponseLines.Length - 3; i++)
                HeaderData[i - 1] = httpResponseLines[i];
        }

        private void DetermineHttpResponseCode(string[] httpResponseLines)
        {
            if (httpResponseLines.Length <= 0)
                return;
            if (!httpResponseLines[0].StartsWith("HTTP"))
                return;

            var httpResponseCode = httpResponseLines[0].Split(' ');
            HttpResponseCode = int.Parse(httpResponseCode[1]);
        }
    }
}