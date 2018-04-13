namespace ViolationReportLib.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UDef")]
    public partial class UDef
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int EObject { get; set; }

        public int? IDTI { get; set; }

        public int? OP { get; set; }

        public int? NPP { get; set; }

        public int? VPP { get; set; }

        public float? NAP { get; set; }

        public float? VAP { get; set; }

        public int? IDTI2 { get; set; }

        public bool? InControl2 { get; set; }

        public bool? InControl { get; set; }

        [StringLength(6)]
        public string OP_OI { get; set; }

        [StringLength(6)]
        public string NPP_OI { get; set; }

        [StringLength(6)]
        public string VPP_OI { get; set; }

        public bool K3P { get; set; }

        [StringLength(2)]
        public string Phase { get; set; }

        public float? MaxWorkU { get; set; }

        public Guid rowguid { get; set; }
    }
}
