using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolationReportLib
{
    public class VoltageGraphItem
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double UpperWarningLimit { get; set; }
        public double LowerWarningLimit { get; set; }
    }
}
