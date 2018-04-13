using System;
using System.Collections.Generic;
using System.Linq;

namespace ViolationReportLib
{
    public class VoltageControlObject
    {
        private VoltageNsi _nsi;

        private VoltageGraphItem[] _graph;
        private Measurement[] _measurements;
        private VoltageViolation[] _violations;

        public string Name { get { return _nsi.ObjectName; } }

        public VoltageControlObject(VoltageNsi nsi)
        {
            _nsi = nsi;
            VoltageViolation.Reset();
        }

        private void SetGraph(DateTime startTime, DateTime endTime)
        {
            var lowerLimits = DataSource.ReadFromOik(_nsi.LowerLimitCategory, _nsi.LowerLimitId, startTime, endTime)
                .ToArray();
            var upperLimits = DataSource.ReadFromOik(_nsi.UpperLimitCategory, _nsi.UpperLimitId, startTime, endTime)
                .ToArray();

            var graphItems = new List<VoltageGraphItem>();
            for(int i = 0; i < lowerLimits.Length; i++)
            {
                var graphItem = new VoltageGraphItem
                {
                    StartTime = lowerLimits[i].StartTime,
                    EndTime = lowerLimits[i].EndTime,
                    LowerWarningLimit = lowerLimits[i].Value,
                    UpperWarningLimit = upperLimits[i].Value
                };
                graphItems.Add(graphItem);
            }

            _graph = graphItems.ToArray();
        }

        private void SetMeasurements(DateTime startTime, DateTime endTime)
        {
            _measurements = DataSource.ReadFromOik("I", _nsi.VoltageTiId, startTime, endTime)
                .ToArray();
        }

        public VoltageReportItem ToVoltageReportItem()
        {
            return new VoltageReportItem
            {
                ObjectName = _nsi.ObjectName,
                Violations = _violations
            };
        }

        public void FindViolations(DateTime startTime, DateTime endTime)
        {
            SetGraph(startTime, endTime);
            SetMeasurements(startTime, endTime);

            var violations = new List<VoltageViolation>();

            int graphItemIndex = 0;
            var currentGraphSegment = _graph[graphItemIndex];
            for(int i = 0; i < _measurements.Length; i++)
            {
                var measurement = _measurements[i];

                if (measurement.StartTime > currentGraphSegment.EndTime)
                    currentGraphSegment = _graph[++graphItemIndex];

                if (measurement.IsOutOfGraph)
                    violations.Add(new VoltageViolation(measurement, currentGraphSegment));
            }

            _violations = violations.ToArray();
        }
    }
}
