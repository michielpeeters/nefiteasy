namespace NefitEasy.Parsing
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Internal;

    public class NefitEasyProgramParser
    {
        public ICollection<ProgramSwitch> Execute(ICollection<NefitEasyProgram> nefitPrograms)
        {
            var programs = new List<ProgramSwitch>();
            programs.AddRange(nefitPrograms.Where(program => program.active.Equals("on")).Select(program => new ProgramSwitch(program)));
            programs.Sort((p1, p2) => p1.Timestamp.CompareTo(p2.Timestamp));
            return programs;
        }
    }
}