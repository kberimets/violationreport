using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViolationReportLib;

namespace ViolationReport
{
    public class VoltageViolationViewItem : ViolationViewItem
    {
        public VoltageViolationViewItem(VoltageViolation violation)
        {
            StartTime = violation.Start;
            EndTime = violation.End;
            Duration = violation.Duration;
            
            if(violation.Type == VoltageViolationType.Umin)
            {
                LowerLimit = violation.Limit;
                Umin = violation.Value;
            }
            else
            {
                UpperLimit = violation.Limit;
                Umax = violation.Value;
            }
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double? UpperLimit { get; set; }
        public double? LowerLimit { get; set; }
        public double? Umax { get; set; }
        public double? Umin { get; set; }
    }
}
