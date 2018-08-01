namespace NefitEasy.Models
{
    using System;
    using Enumerations;
    using Internal;
    using Parsing;

    public class ProgramSwitch
    {
        public DateTime Timestamp { get; }

        public ProgramName Name { get; }

        public double Temperature { get; }

        internal ProgramSwitch(NefitSwitch program)
        {
            var date = new NefitEasyDateParser().GetNextDate(program.d, program.t);
            Timestamp = date;
            Temperature = program.T;
        }

        internal ProgramSwitch(NefitEasyProgram program)
        {
            var date = new NefitEasyDateParser().GetNextDate(program.d, program.t);
            Timestamp = date;
            Name = (ProgramName) program.name;
            Temperature = program.T;
        }
    }
}