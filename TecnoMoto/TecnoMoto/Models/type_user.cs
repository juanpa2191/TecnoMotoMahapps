using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMoto.Models
{
    [Table("type_user")]
    public class type_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public type_user()
        {
            users = new HashSet<users>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_TYPE_USER { get; set; }

        [StringLength(100)]
        public string TYPE_USER { get; set; }

        public DateTime? DATE_REGISTER { get; set; }

        public virtual ICollection<users> users { get; set; }
    }
}
