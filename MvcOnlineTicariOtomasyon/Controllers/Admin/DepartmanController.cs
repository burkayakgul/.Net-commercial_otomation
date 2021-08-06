using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var departmanlar = context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmanlar);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanSil(int id)
        {
            var dep = context.Departmans.Find(id);
            dep.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGuncelle(int id)
        {
            var dep = context.Departmans.Find(id);
            return View(dep);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dep = context.Departmans.Find(departman.DepartmanId);
            dep.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.DepertmanAd = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var DepartmanPersonel = context.SatisHarekets.Where(x => x.PersonelId == id).Select(y => y.Personel.PersonelAd +" " +  y.Personel.PersonelSoyad).FirstOrDefault();
            ViewBag.DepartmanPersonel = DepartmanPersonel;
            return View(degerler);
        }
    }
}