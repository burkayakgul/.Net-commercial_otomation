using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MvcOnlineTicariOtomasyon.ViewModels;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            List<Urun> urunler = context.Uruns.Where(u => u.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> kate = (from x in context.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString()
                                         }).ToList();

            ViewBag.kate = kate;
            UrunViewModel urunViewModel = new UrunViewModel();
            return View(urunViewModel);
        }

        [HttpPost]
        public ActionResult YeniUrun(FormCollection collection)
        {
            string comment = collection["Renk"];
            List<UrunOzellik> urnoz = new List<UrunOzellik>();


            Urun urn = new Urun();
            urn.UrunAd = collection["Urun.UrunAd"];
            urn.Aciklama = collection["Urun.Aciklama"];
            urn.AlisFiyati = Convert.ToDecimal(collection["Urun.AlisFiyati"]);
            urn.SatisFiyati = Convert.ToDecimal(collection["Urun.SatisFiyati"]);
            urn.Durum = true;
            urn.KategoriId = Convert.ToInt32(collection["Urun.KategoriId"]);
            context.UrunMarkaModels.Add(
                new UrunMarkaModel()
                {
                    MarkaId = Convert.ToInt32(collection["UrunMarkaModel.MarkaId"]),
                    ModelId = Convert.ToInt32(collection["UrunMarkaModel.ModelId"])
                }
            );
            context.SaveChanges();
            Urun urn2 = context.Uruns.Find(context.Uruns.Last().UrunId);
            urn2.UrunMarkaModelId = context.UrunMarkaModels.Last().UrunMarkaModelId;
            int sayac = 1;
            var ozellikdeger = new UrunOzellik();
            for (sayac = 1; sayac < context.Ozelliks.Count(); sayac++)
            {
                string name = context.Ozelliks.Where(x => x.OzellikId == sayac).Select(y => y.OzellikAd).FirstOrDefault();
                if (collection[name] != "")
                {
                    ozellikdeger.UrunId = context.Uruns.Last().UrunId;
                    ozellikdeger.DegerId = Convert.ToInt32(collection[name]);
                    ozellikdeger.OzellikId = sayac;
                    urn2.UrunOzelliks.Add(ozellikdeger);
                }
            }
            context.SaveChanges();

            //if (Request.Files.Count > 0)
            //{
            //    string dosyaadi = (urun.UrunId).ToString();
            //    List<UrunGorsel> resimlist = new List<UrunGorsel>();
            //    UrunGorsel resim = new UrunGorsel();
            //    for (int u = 0; u < Request.Files.Count; u++)
            //    {
            //        string uzanti = Path.GetExtension(Request.Files[$"resim-{u}"].FileName);
            //        string yol = $"~/lib/Image/Urun/{urun.UrunId}/" + u + uzanti;
            //        Directory.CreateDirectory(Server.MapPath($"~/lib/Image/Urun/{urun.UrunId}/"));
            //        Request.Files[0].SaveAs(Server.MapPath(yol));

            //        resim.Dizin = "/lib/Image/Urun/" + "/" + urun.UrunId + "/" + u + uzanti;
            //        resim.UrunId = urun.UrunId;
            //        resimlist.Add(resim);
            //    }
            //    context.UrunGorsels.AddRange(resimlist);
            //}
            //context.Uruns.Add(urun);
            //context.SaveChanges();
            //HttpPostedFileBase file = Request.Files["myFile"];
            return Redirect("Index");
        }

        public JsonResult MarkaGetir(int id)
        {
            List<SelectListItem> markalar = (from y in context.KategoriMarkas.Where(x => x.KategoriId == id).ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.Marka.MarkaAd,
                                             Value = y.MarkaId.ToString()
                                         }).ToList();
            string json = JsonConvert.SerializeObject(markalar);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult ModelGetir(int id)
        {
            List<SelectListItem> modeller = (from y in context.Models.Where(x => x.MarkaId == id).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.ModelAd,
                                                 Value = y.ModelId.ToString()
                                             }).ToList();
            string json = JsonConvert.SerializeObject(modeller);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OzellikGetir(int id)
        {
            List<SelectListItem> ozellik = (from y in context.KategoriOzelliks.Where(x => x.KategoriId == id).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.Ozellik.OzellikAd,
                                                 Value = y.OzellikId.ToString()
                                             }).ToList();

            string json = JsonConvert.SerializeObject(ozellik);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DegerGetir(int id)
        {
            List<SelectListItem> ozellik = (from y in context.Degerlers.Where(x => x.OzellikId == id).ToList()
                                            select new SelectListItem
                                            {
                                                Text = y.DegerAd,
                                                Value = y.Id.ToString()
                                            }).ToList();

            string json = JsonConvert.SerializeObject(ozellik);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult UrunSil(int id)
        //{
        //    var urun = context.Uruns.Find(id);
        //    urun.Durum = false;
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult UrunGetir(int id)
        //{
        //    List<SelectListItem> kate = (from x in context.Kategoris.ToList()
        //                                 select new SelectListItem
        //                                 {
        //                                     Text = x.KategoriAd,
        //                                     Value = x.KategoriId.ToString()
        //                                 }).ToList();

        //    ViewBag.kate = kate;
        //    var urun = context.Uruns.Find(id);
        //    return View(urun);
        //}


        //[HttpPost]
        //public ActionResult UrunGetir(Urun urun)
        //{
        //    var urn = context.Uruns.Find(urun.UrunId);
        //    if (Request.Files.Count > 0)
        //    {
        //        string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
        //        string uzanti = Path.GetExtension(Request.Files[0].FileName);
        //        string yol = "~/lib/Image/Urun/" + urun.UrunId + uzanti;
        //        Request.Files[0].SaveAs(Server.MapPath(yol));
        //        urun.UrunGorsel = "/lib/Image/Urun/" + urun.UrunId + uzanti;
        //    }
        //    urn.AlisFiyati = urun.AlisFiyati;
        //    urn.Durum = urun.Durum;
        //    urn.KategoriId = urun.KategoriId;
        //    //urn.MarkaId = urun.MarkaId;
        //    //urn.ModelId = urun.ModelId;
        //    //urn.SatisFiyati = urun.SatisFiyati;
        //    //urn.Stok = urun.Stok;
        //    //urn.UrunAd = urun.UrunAd;
        //    //urn.UrunGorsel = urun.UrunGorsel;
        //    //context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}