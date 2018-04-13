using System;

namespace ViolationReportLib
{
    public class VoltageViolation : Violation
    {
        private static int groupNumber = 0;
        private static Measurement prevMeasurement = null;

        public VoltageViolation() { }

        public VoltageViolation(Measurement measurement, VoltageGraphItem graphSegment)
        {
            Start = measurement.StartTime;
            End = measurement.EndTime;
            Value = measurement.Value;

            if (measurement.IsLowerViolation)
            {
                Limit = graphSegment.LowerWarningLimit;
                Type = VoltageViolationType.Umin;
            }
            else
            {
                Limit = graphSegment.UpperWarningLimit;
                Type = VoltageViolationType.Umax;
            }

            if (prevMeasurement != null)
            {
                var distanceInSeconds = (measurement.StartTime - prevMeasurement.EndTime).Seconds;
                if (distanceInSeconds > 1) groupNumber++;
            }
            else groupNumber++;

            GroupNumber = groupNumber;

            prevMeasurement = measurement;
        }

        public static void Reset()
        {
            groupNumber = 0;
            prevMeasurement = null;
        }

        public int GroupNumber { get; set; }
        public double Value { get; set; }
        public double Limit { get; set; }
        public VoltageViolationType Type { get; set; }
        public override string ToString()
        {
            return $"Type: {Type}" + Environment.NewLine +
                   $"Value: {Value}" + Environment.NewLine +
                   $"Limit: {Limit}" + Environment.NewLine +
                   $"Start: {Start}" + Environment.NewLine +
                   $"End: {End}" + Environment.NewLine +
                   $"Duration: {Duration}" + Environment.NewLine +
                   $"GroupNumber: {GroupNumber}" + Environment.NewLine;
        }
    }
}
