using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class UrunGorsel
    {
        public int UrunGorselId { get; set; }

        public string Dizin { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }
}