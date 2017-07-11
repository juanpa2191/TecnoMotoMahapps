namespace TecnoMoto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock")]
    public partial class stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_STOCK { get; set; }

        public long? TOTAL_PRODUCT { get; set; }

        public long? ID_PRODUCT { get; set; }

        public virtual product product { get; set; }
    }
}
