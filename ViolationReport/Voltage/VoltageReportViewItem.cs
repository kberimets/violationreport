using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViolationReportLib;

namespace ViolationReport
{
    public class VoltageReportViewItem : ReportViewItem
    {
        public string ObjectName { get; set; }
        public VoltageViolationViewItem[] Violations { get; set; }
        public VoltageReportViewItem(VoltageReportItem reportItem)
        {
            ObjectName = reportItem.ObjectName;

            var violations = new List<VoltageViolationViewItem>();

            foreach (var violation in reportItem.LongViolations)
                violations.Add(new VoltageViolationViewItem(violation));

            Violations = violations.ToArray();
        }

        public VoltageReportViewItem() { }
    }
}
