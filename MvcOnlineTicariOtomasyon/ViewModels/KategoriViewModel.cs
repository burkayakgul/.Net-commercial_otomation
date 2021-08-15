using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.ViewModels
{
    public class KategoriViewModel
    {
        public  List<Kategori> Kategoris { get; set; }

        public  List<Marka> Markas { get; set; }

        public  List<Ozellik> Ozelliks { get; set; }
    }
}