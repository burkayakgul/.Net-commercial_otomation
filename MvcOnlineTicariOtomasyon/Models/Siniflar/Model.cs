using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }

        public string ModelAd { get; set; }

        public int MarkaId { get; set; }
        public Marka Marka { get; set; }
    }
}