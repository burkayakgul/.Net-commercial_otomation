using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KategoriOzellik
    {
        [Key]
        [Column(Order = 1)]
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        [Key]
        [Column(Order = 2)]
        public int OzellikId { get; set; }
        public virtual Ozellik Ozellik { get; set; }
    }
}