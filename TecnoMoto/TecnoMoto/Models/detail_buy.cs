using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMoto.Models
{
    [Table("detail_buy")]
    public partial class detail_buy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID_DETAIL_BUY { get; set; }

        public long? ID_PRODUCT { get; set; }

        public long? ID_BUY { get; set; }

        public long? VALUE { get; set; }

        public long? CANT { get; set; }

        public virtual buy buy { get; set; }

        public virtual product product { get; set; }
    }

}
