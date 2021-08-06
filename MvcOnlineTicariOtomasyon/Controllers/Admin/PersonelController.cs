using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var personel = context.Personels.ToList();

            return View(personel);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanId.ToString()
                                              }).ToList();
            ViewBag.departman = departman;
            return View();
        }


        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if(Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
            }
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelGuncelle(int id)
        {
            var personel = context.Personels.Find(id);
            List<SelectListItem> departman = (from x in context.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanId.ToString()
                                              }).ToList();
            ViewBag.departman = departman;
            ViewBag.personelAd = personel.PersonelAd + " " + personel.PersonelSoyad;
            return View(personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel)
        {
            var pers = context.Personels.Find(personel.PersonelId);
            pers.PersonelAd = personel.PersonelAd;
            pers.PersonelSoyad = personel.PersonelSoyad;
            pers.PersonelGorsel = personel.PersonelGorsel;
            pers.DepartmanId = personel.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}