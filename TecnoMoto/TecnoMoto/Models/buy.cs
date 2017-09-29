using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMoto.Models
{
    [Table("buy")]
    public partial class buy
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public buy()
        {
            detail_buy = new HashSet<detail_buy>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_BUY { get; set; }

        public DateTime? DATE_REGISTER { get; set; }

        public long ID_USER { get; set; }

        public bool COMPLETE { get; set; }

        public virtual users users { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detail_buy> detail_buy { get; set; }
    }
}
