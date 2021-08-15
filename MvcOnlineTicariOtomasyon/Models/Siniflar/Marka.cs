using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Marka
    {
        [Key]
        public int MarkaId { get; set; }

        public string MarkaAd { get; set; }
        public virtual List<Model> Models { get; set; }
        public List<KategoriMarka> kategoriMarkas { get; set; }

    }
}