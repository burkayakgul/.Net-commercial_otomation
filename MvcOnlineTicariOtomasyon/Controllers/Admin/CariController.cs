using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var cariler = context.Carilers.Where(x => x.Durum == true).ToList();
            return View(cariler);
        }

        [HttpGet]
        public ActionResult YeniCariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCariEkle(Cariler cari)
        {
            cari.Durum = true;
            context.Carilers.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Carilers.Find(id);
            context.Carilers.Remove(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGuncelle(int id)
        {
            Cariler cari = context.Carilers.Find(id);
            ViewBag.cariad = cari.CariAd + " " + cari.CariSoyad;
            return View(cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGuncelle");
            }
            Cariler cr = context.Carilers.Find(cari.CariId);
            cr.CariAd = cari.CariAd;
            cr.CariSoyad = cari.CariSoyad;
            cr.CariMail = cari.CariMail;
            cr.CariSehir = cari.CariSehir;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatisDetay(int id)
        {
            var satislar = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var CariAd = context.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAd = CariAd;
            return View(satislar);
        }
    }
}