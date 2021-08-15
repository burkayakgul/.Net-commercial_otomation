using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class UrunMarkaModel
    {
        public int UrunMarkaModelId { get; set; }
        public int? MarkaId { get; set; }
        public int? ModelId { get; set; }

        public virtual Marka Marka { get; set; }

        public virtual Model Model { get; set; }
        public Urun Urun { get; set; }
    }
}