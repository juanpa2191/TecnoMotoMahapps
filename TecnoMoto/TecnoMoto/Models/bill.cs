namespace TecnoMoto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            detail_bill = new HashSet<detail_bill>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_BILL { get; set; }

        public long? ID_USER { get; set; }

        public DateTime? DATE_REGISTER { get; set; }

        public string DX { get; set; }

        public string PLAQUE { get; set; }

        public bool COMPLETE { get; set; }

        public virtual users users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detail_bill> detail_bill { get; set; }
    }
}
