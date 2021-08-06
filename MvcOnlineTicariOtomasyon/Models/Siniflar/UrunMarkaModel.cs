using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class UrunMarkaModel
    {
        public int UrunMarkaModelId { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        
        public Urun Urun { get; set; }
    }
}