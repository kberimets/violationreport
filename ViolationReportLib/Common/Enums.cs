namespace ViolationReportLib
{
    public enum VoltageViolationType
    {
        Umin, Umax
    }

    public enum VoltageQualityCode
    {
        OutOfUpperWarning = 0x20000,
        OutOfLowerWarning = 0x40000,
        OutOfUpperAccident = 0x200000,
        OutOfLowerAccidend = 0x10000
    }

    public enum LimitMask
    {
        Lower = 0x50000,
        Upper = 0x220000
    }
}
