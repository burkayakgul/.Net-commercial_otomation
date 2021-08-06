using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        public string Aciklama { get; set; }

        public List<Stok> Stok { get; set; }

        public decimal AlisFiyati { get; set; }

        public decimal SatisFiyati { get; set; }


        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public virtual List<UrunGorsel> UrunGorsels { get; set; }

        public int KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual List<UrunOzellik> UrunOzelliks { get; set; }

        public virtual List<SatisHareket> SatisHarekets { get; set; }

        public int UrunMarkaModelId { get; set; }
        [Required]
        public virtual UrunMarkaModel UrunMarkaModel { get; set; }
        public int MarkaId { get; internal set; }
    }
}