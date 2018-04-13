using System;

namespace ViolationReportLib
{
    public class VoltageNsi
    {
        public int ObjectId { get; set; }
        public string ObjectName { get; set; }
        public int VoltageTiId { get; set; }
        public string VoltageTiName { get; set; }
        public string LowerLimitCategory { get; set; }
        public int LowerLimitId { get; set; }
        public string UpperLimitCategory { get; set; }
        public int UpperLimitId { get; set; }

        public override string ToString()
        {
            return $"ObjectId: {ObjectId}" + Environment.NewLine +
                   $"ObjectName: {ObjectName}" + Environment.NewLine +
                   $"VoltageTiId: {VoltageTiId}" + Environment.NewLine +
                   $"VoltageTiName: {VoltageTiName}" + Environment.NewLine +
                   $"LowerLimitSource: {LowerLimitCategory}{LowerLimitId}" + Environment.NewLine +
                   $"UpperLimitSource: {UpperLimitCategory}{UpperLimitId}";
        }
    }
}
