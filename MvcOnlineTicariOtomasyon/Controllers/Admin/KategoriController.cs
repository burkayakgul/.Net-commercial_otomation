using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.ViewModels;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        Context context = new Context();

        // GET: Kategori
        public ActionResult Index()
        {
            KategoriViewModel kategoriViewModel = new KategoriViewModel();
            kategoriViewModel.Kategoris = context.Kategoris.ToList();
            kategoriViewModel.Markas = context.Markas.ToList();
            kategoriViewModel.Ozelliks = context.Ozelliks.ToList();

            return View(kategoriViewModel);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = context.Kategoris.Find(id);
            context.Kategoris.Remove(ktg);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            
            var ktg = context.Kategoris.Find(id);
            return View(ktg);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            Kategori ktg = context.Kategoris.Find(kategori.KategoriId);
            ktg.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}