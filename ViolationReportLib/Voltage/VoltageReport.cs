using System;
using System.Collections.Generic;
using System.Linq;

namespace ViolationReportLib
{
    public class VoltageReport
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public VoltageReport(DateTime startTime, DateTime endTime)
        {
            _startTime = startTime;
            _endTime = endTime;
        }

        public IEnumerable<VoltageReportItem> Generate()
        {
            var reportItems = new List<VoltageReportItem>();

            var controlObjects = DataSource.GetControlObjects();
            foreach(var controlObject in controlObjects)
            {
                controlObject.FindViolations(_startTime, _endTime);
                reportItems.Add(controlObject.ToVoltageReportItem());
            }
            return reportItems
                .Where(item => item.Violations.Any())
                .ToArray();
        }      
    }
}
