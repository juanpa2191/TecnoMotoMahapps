namespace TecnoMoto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("users")]
    public partial class users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_USER { get; set; }

        [StringLength(255)]
        public string USERNAME { get; set; }

        [StringLength(20)]
        public string PASS { get; set; }

        [Column("USERS")]
        [StringLength(20)]
        public string USERS { get; set; }

        [StringLength(200)]
        public string CARGO { get; set; }
    }
}
