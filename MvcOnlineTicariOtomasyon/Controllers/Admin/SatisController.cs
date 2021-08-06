using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();

            return View(degerler);
        }


        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> cariler = (from x in context.Carilers.ToList()
                                            select new SelectListItem {
                                                       Text = x.CariAd + " " + x.CariSoyad,
                                                       Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.cariler = cariler;

            List<SelectListItem> personeller = (from x in context.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personeller = personeller;


            ICollection<Urun> urunler = context.Uruns.ToList();

            ViewBag.urunler = urunler;

            return View();
        }


        [HttpPost]
        public ActionResult SatisEkle(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisGuncelle(int id)
        {
            var satis = context.SatisHarekets.Find(id);
            List<SelectListItem> cariler = (from x in context.Carilers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CariAd + " " + x.CariSoyad,
                                                Value = x.CariId.ToString()
                                            }).ToList();
            ViewBag.cariler = cariler;

            List<SelectListItem> personeller = (from x in context.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personeller = personeller;

            ICollection<Urun> urunler = context.Uruns.ToList();

            ViewBag.urunler = urunler;
            return View(satis);
        }


        //[HttpPost]
        //public ActionResult SatisGuncelle(SatisHareket satis)
        //{
        //    //var sts = context.SatisHarekets.Find(satis.SatisId);
        //    sts.PersonelId = satis.PersonelId;
        //    sts.UrunId = satis.UrunId;
        //    sts.CariId = satis.CariId;
        //    sts.Adet = satis.Adet;
        //    sts.Fiyat = satis.Fiyat;
        //    sts.ToplamTutar = satis.ToplamTutar;
        //    sts.Tarih = satis.Tarih;
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult SatisDetay(int id)
        {
            var satis = context.SatisHarekets.Find(id);
            return View(satis);
        }
    }
}