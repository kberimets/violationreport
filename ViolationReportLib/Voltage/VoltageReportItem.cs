using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViolationReportLib
{
    public class VoltageReportItem
    {
        public VoltageReportItem(string objectName, VoltageViolation _)

        public string ObjectName { get; set; }
        public VoltageViolation[] Violations { get; set; }        
    }
}
