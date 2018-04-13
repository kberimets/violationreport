namespace ViolationReportLib.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AllTI")]
    public partial class AllTI
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Category { get; set; }

        public bool OutOfWork { get; set; }

        public int EObject { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(32)]
        public string Abbr { get; set; }

        public int Type { get; set; }

        public int Unit { get; set; }

        public float? NFP { get; set; }

        public float? VFP { get; set; }

        public float? NAP { get; set; }

        public float? VAP { get; set; }

        public float? NPP { get; set; }

        public float? VPP { get; set; }

        public int? CutOffTS { get; set; }

        public float? SFactor { get; set; }

        public int? TRenewalTime { get; set; }

        public float? TPlanDev { get; set; }

        public float? TEstimDev { get; set; }

        public float? TDublDev { get; set; }

        public bool RenEn { get; set; }

        public byte LeapEn { get; set; }

        public bool PDevEn { get; set; }

        public bool EstimDevEn { get; set; }

        public bool CutOffEn { get; set; }

        public bool DDiscrEn { get; set; }

        public bool FBoundEn { get; set; }

        public int? RDup1 { get; set; }

        public bool SDup1 { get; set; }

        public int? RDup2 { get; set; }

        public bool SDup2 { get; set; }

        public int? RDup3 { get; set; }

        public bool SDup3 { get; set; }

        public int? DRepID { get; set; }

        public bool SRepID { get; set; }

        public int? EstimID { get; set; }

        public int? PlanID { get; set; }

        public int? FcastID { get; set; }

        public bool DRepEn { get; set; }

        public bool EstimEn { get; set; }

        public bool PlanEn { get; set; }

        public bool FcastEn { get; set; }

        public int? Signif { get; set; }

        public float? Aperture { get; set; }

        public float TLeapE { get; set; }

        public float TLeapQ { get; set; }

        public float Scale { get; set; }

        public int LeapTI1 { get; set; }

        public int LeapTI2 { get; set; }

        public int LeapTI3 { get; set; }

        public int? TNAP { get; set; }

        public int? TVAP { get; set; }

        public int? TNPP { get; set; }

        public int? TVPP { get; set; }

        public int? OIsrc { get; set; }

        public int? TProtocol { get; set; }

        public bool? DNAP { get; set; }

        public bool? DVAP { get; set; }

        public bool? DNPP { get; set; }

        public bool? DVPP { get; set; }

        public float? NormalValue { get; set; }

        public bool EnableIntegDeadBand { get; set; }

        public bool Enable_IMTS { get; set; }

        public bool Sqz { get; set; }

        public bool SqzPercentOn { get; set; }

        public int SqzTMin { get; set; }

        public double SqzWidthPercent { get; set; }

        public int SqzTMax { get; set; }

        public Guid? MRID { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }
    }
}
