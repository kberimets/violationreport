using System;

namespace ViolationReportLib
{
    public class Measurement
    {
        public double Value { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int QualityCode { get; set; }

        public bool IsOutOfGraph
        {
            get { return IsLowerViolation || IsUpperViolation; }
        }

        public bool IsLowerViolation
        {
            get { return (QualityCode & (int)LimitMask.Lower) != 0 ? true : false; }                
        }

        public bool IsUpperViolation
        {
            get { return (QualityCode & (int)LimitMask.Upper) != 0 ? true : false; }
        }

        public override string ToString()
        {
            return $"Value: {Value}" + Environment.NewLine +
                   $"Time: {StartTime}" + Environment.NewLine +
                   $"Quality code: {QualityCode}";
        }


    }
}
