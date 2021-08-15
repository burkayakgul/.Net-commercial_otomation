using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class UrunOzellik
    {
        [Key]
        [Column(Order = 1)]
        public int UrunOzellikId { get; set; }

        public int OzellikId { get; set; }

        public int DegerId { get; set; }
        public int UrunId { get; set; }

        public virtual Ozellik Ozellik { get; set; }
        public Urun Urun { get; set; }
    }
}