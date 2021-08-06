using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YazdirController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrunYazdir()
        {
            var urunler = context.Uruns.ToList();
            return View(urunler);
        }
    }
}