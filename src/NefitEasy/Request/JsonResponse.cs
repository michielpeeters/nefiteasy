namespace NefitEasy.Request
{
    public class JsonResponse<TValue>
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public int Recordable { get; set; }

        public int Writable { get; set; }

        public TValue Value { get; set; }
    }
}