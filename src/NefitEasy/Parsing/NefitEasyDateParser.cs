namespace NefitEasy.Parsing
{
    using System;

    public class NefitEasyDateParser
    {
        public DateTime GetNextDate(string day, int time)
        {
            var dayOfWeek = GetDayOfWeek(day);
            var date = DateTime.Today;

            while (date.DayOfWeek != dayOfWeek)
                date = date.AddDays(1);

            date = date.AddMinutes(time);

            return date;
        }

        private DayOfWeek GetDayOfWeek(string day)
        {
            DayOfWeek dayOfWeek;
            switch (day)
            {
                case "Mo":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "Tu":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "We":
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "Th":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "Fr":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case "Sa":
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
                default:
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
            }

            return dayOfWeek;
        }
    }
}