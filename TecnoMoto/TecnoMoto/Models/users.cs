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
        public users()
        {
            bill = new HashSet<bill>();
            buy = new HashSet<buy>();
        }

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

        [StringLength(10)]
        public string PHONE { get; set; }

        [StringLength(50)]
        public string DOCUMENT { get; set; }

        public long ID_TYPE_USER { get; set; }

        public virtual type_user type_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<buy> buy { get; set; }

    }
}
