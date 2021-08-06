using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var toplamcari = context.Carilers.Count().ToString();
            ViewBag.toplamcari = toplamcari;

            var toplamurun = context.Uruns.Count().ToString();
            ViewBag.toplamurun = toplamurun;

            var toplampersonel = context.Personels.Count().ToString();
            ViewBag.toplampersonel = toplampersonel;

            var toplamkategori = context.Kategoris.Count().ToString();
            ViewBag.toplamkategori = toplamkategori;

            

            //var markasayisi = (from x in context.Uruns select x.MarkaId).Distinct().Count().ToString();
            //ViewBag.markasayisi = markasayisi;

            


            var enyuksekfiyat = (from x in context.Uruns select x.SatisFiyati).Max().ToString();
            ViewBag.enyuksekfiyat = enyuksekfiyat;
            return View();
        }
    }
}