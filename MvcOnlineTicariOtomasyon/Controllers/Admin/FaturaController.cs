using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();


        public ActionResult Index()
        {
            var faturalar = context.Faturalars.ToList();
            return View(faturalar);
        }


        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult FaturaGuncelle(int id)
        {
            var fatura = context.Faturalars.Find(id);
            return View(fatura);
        }


        [HttpPost]
        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var ftr = context.Faturalars.Find(fatura.FaturaId);
            ftr.FaturaKalems = fatura.FaturaKalems;
            ftr.FaturaSeriNo = fatura.FaturaSeriNo;
            ftr.FaturaSıraNo = fatura.FaturaSıraNo;
            ftr.Saat = fatura.Saat;
            ftr.Tarih = fatura.Tarih;
            ftr.TeslimAlan = fatura.TeslimAlan;
            ftr.TeslimEden = fatura.TeslimEden;
            ftr.VergiDairesi = fatura.VergiDairesi;
            ftr.Toplam = fatura.Toplam;
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult FaturaDetay(int id)
        {
            var faturakalem = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            var toplam = context.FaturaKalems.Where(x => x.FaturaId == id).Sum(y => y.SatisHareket.ToplamTutar);
            var kdvsi = ((float)toplam * 0.18);
            var geneltoplam = (double)toplam + kdvsi;
            var fatura = context.Faturalars.FirstOrDefault();
            ViewBag.fatura = fatura;
            ViewBag.toplam = toplam;
            ViewBag.kdvsi = kdvsi;
            ViewBag.geneltoplam = geneltoplam;
            ViewBag.parayazi = paraToYazi(geneltoplam);
            ViewBag.geneltoplam = geneltoplam;
            return View(faturakalem);
        }

        //[HttpGet]
        //public ActionResult FaturaKalemEkle()
        //{
        //    //var fatura = context.
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem)
        //{
        //    //var ftrkalem = context.FaturaKalems.Find(faturaKalem.FaturaKalemId);
        //    //ftrkalem.Aciklama = faturaKalem.Aciklama;
        //    //ftrkalem.BirimFiyat = faturaKalem.BirimFiyat;
        //    //ftrkalem.Miktar = faturaKalem.Miktar;
        //    //ftrkalem.Tutar = faturaKalem.Tutar;
        //    //context.SaveChanges();
        //    //return RedirectToAction($"FaturaDetay/{faturaKalem.FaturaId}");
        //}

        public string paraToYazi(double sayi)
        {

            string sTutar = sayi.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { " KATRİLYON ", " TRİLYON ", " MİLYAR ", " MİLYON ", " BİN ", " " }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TÜRK LİRASI ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " KURUŞ.";
            else
                yazi += " #";

            return "# " + yazi;



        }
    }
}