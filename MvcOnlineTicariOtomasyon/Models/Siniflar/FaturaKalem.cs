using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }

        //[ForeignKey("SatisHareketId")]
        public int SatisHareketId { get; set; }
        //[InverseProperty("SatisHareket")]
        [Required]
        public virtual SatisHareket SatisHareket { get; set; }
        
        public int FaturaId { get; set; }
        
        public virtual Faturalar Faturalar { get; set; }
    }
}