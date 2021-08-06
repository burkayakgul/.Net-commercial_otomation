using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Degerler
    {
        [Key]
        public int Id { get; set; }

        public string DegerAd { get; set; }

        public string Deger1 { get; set; }
        public string Deger2 { get; set; }

        public int OzellikId { get; set; }
        public Ozellik Ozellik { get; set; }
    }
}