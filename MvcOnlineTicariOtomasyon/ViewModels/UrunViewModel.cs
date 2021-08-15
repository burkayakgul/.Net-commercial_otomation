using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.ViewModels
{
    public class UrunViewModel
    {
        Context context = new Context();
        public UrunViewModel()
        {
            this.Urun = new Urun();
            this.Stok = new Stok();
            this.UrunGorsels = new List<UrunGorsel>();
            this.UrunMarkaModel = new UrunMarkaModel();
            this.Ozelliks = context.Ozelliks.ToList().ToArray();
            for(int i = 0; i < Ozelliks.Length; i++)
            {
               Ozelliks[i].Degerlers = context.Degerlers.Where(x => x.OzellikId == i+1).ToList(); 
            }
            this.UrunOzelliks = new List<UrunOzellik>();
        }


        public Urun Urun { get; set; }

        public Stok Stok { get; set; }

        public List<UrunGorsel> UrunGorsels { get; set; }

        public virtual Ozellik[] Ozelliks { get; set; }

        public virtual List<UrunOzellik> UrunOzelliks { get; set; }
        public UrunMarkaModel UrunMarkaModel { get; set; }
    }
}