namespace TecnoMoto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detail_bill")]
    public partial class detail_bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_DETAIL_BILL { get; set; }

        public long? ID_PRODUCT { get; set; }

        public long? ID_BILL { get; set; }

        public long? VALUE { get; set; }

        public virtual bill bill { get; set; }

        public virtual product product { get; set; }
    }
}
