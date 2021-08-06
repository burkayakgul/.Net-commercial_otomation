using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Ozellik
    {
        [Key]
        public int OzellikId { get; set; }

        public string OzellikAd { get; set; }
        public List<Degerler> Degerlers { get; set; }


        public List<KategoriOzellik> KategoriOzelliks { get; set; }
    }
}