using System;

namespace ViolationReportLib
{
    public class Violation
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration => End - Start + new TimeSpan(0, 0, 1);
    }
}
