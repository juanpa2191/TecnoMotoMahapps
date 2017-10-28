namespace TecnoMoto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            detail_bill = new HashSet<detail_bill>();
            detail_buy = new HashSet<detail_buy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_PRODUCT { get; set; }

        [StringLength(255)]
        public string NAME_PRODUCT { get; set; }
        [StringLength(255)]

        public string CODE_PRODUCT { get; set; }

        public bool ACTIVE { get; set; }

        public long ID_TYPE_PRODUCT { get; set; }

        public long VALUE_PRODUCT_BUY { get; set; }

        public long VALUE_PRODUCT_BILL { get; set; }

        public long CANT_PRODUCT { get; set; }
        public long MIN { get; set; }
        public long MAX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detail_bill> detail_bill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detail_buy> detail_buy { get; set; }

        public virtual type_product type_product { get; set; }

    }
}
