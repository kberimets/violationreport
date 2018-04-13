namespace ViolationReportLib.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnObj")]
    public partial class EnObj
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int Cod { get; set; }

        public int? Higher { get; set; }

        public int? Higher2 { get; set; }

        public int Type { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Abbr { get; set; }

        public short? Voltage { get; set; }

        public int? Tag { get; set; }

        public Guid? MRID { get; set; }

        [Column(TypeName = "xml")]
        public string Attributes { get; set; }

        public bool? Ack { get; set; }
    }
}
