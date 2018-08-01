namespace NefitEasy.Models.Internal
{
    public class NefitSwitch : NefitEasyProgram
    {
        public string dhw { get; set; }
    }
 
    public class NefitEasyProgram : NefitProgramBase
    {
        public int name { get; set; }
        public string active { get; set; }
    }
 
    public class NefitProgramBase
    {
        public string d { get; set; }
        public int t { get; set; }
        public double T { get; set; }
    }
}