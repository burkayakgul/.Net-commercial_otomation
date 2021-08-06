using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Stok
    {
        [Key]
        public int Id { get; set; }

        public int StokSayi { get; set; }

        public DateTime StokTarih { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        
    }
}