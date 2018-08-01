namespace NefitEasy.Models
{
    using System.Collections.Generic;

    public class Program
    {
        public IEnumerable<ProgramSwitch> Program1 { get; }

        public IEnumerable<ProgramSwitch> Program2 { get; }

        public int ActiveProgram { get; }

        public Program(IEnumerable<ProgramSwitch> program1, IEnumerable<ProgramSwitch> program2, int activeProgram)
        {
            Program1 = program1;
            Program2 = program2;
            ActiveProgram = activeProgram;
        }
    }
}