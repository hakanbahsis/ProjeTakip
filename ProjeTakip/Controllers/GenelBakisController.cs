using ProjeTakip.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeTakip.Controllers
{
    public class GenelBakisController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();
        // GET: GenelBakis
        public ActionResult Index()
        {
            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;

            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;
            
            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var yuksekOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekOncelikliProje = yuksekOncelikliProjeler; 
            
            var dusukOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukOncelikliProje = dusukOncelikliProjeler;
            
            var ortaOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikliProje = ortaOncelikliProjeler;

            var basariliVeYuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.BasariliVeYuksek = basariliVeYuksek;
            
            var basariliVeOrta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.BasariliVeOrta = basariliVeOrta;
            
            var basariliVeDusuk = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.BasariliVeDusuk = basariliVeDusuk;


            var personelProjeListesi = db.PersonelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>();//personel id ve tmamlanmis proje sayisi çiftleri
            foreach (var personel in db.PersonelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {
                    if (proje.TamamlanmaDurumu==true)
                    {
                        tamamlanmisProjeSayisi++;
                    }
                }
                personelTamamlanmisProjeSayisi[personel.PersonelBilgileriId] = tamamlanmisProjeSayisi;
            }

            var siraliPersonelListesi = personelTamamlanmisProjeSayisi.OrderByDescending(x => x.Value);//tamamlanmış proje sayısına göre personelleri sırala
            var enCokTamamlananPersonelId = siraliPersonelListesi.First().Key;//en çok tamamlanan sayısına sahip personel
            var enCokTamamlananPersonel = db.PersonelBilgileris.FirstOrDefault(p => p.PersonelBilgileriId == enCokTamamlananPersonelId);
            ViewBag.EnCokTamamlayanPersonelBilgisi = enCokTamamlananPersonel.AdSoyad;


            int enCokProjeTamamlayanPersonelProjeSayisi = personelTamamlanmisProjeSayisi[enCokTamamlananPersonelId];
            ViewBag.EnCokProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelProjeSayisi;

            return View();
        }

        public ActionResult GenelIstatistik()
        {
            var personeller = db.PersonelBilgileris.ToList();
            var personelProjeleri = db.PersonelProjeleris.ToList();
            var tamamlanmisProjeSayisi = new Dictionary<int, int>();
            var tamamlanmayanProjeSayisi = new Dictionary<int, int>();
            var toplamProjeSayisi = new Dictionary<int, int>();
            foreach (var personel in personeller)
            {
                int tamamlananProje = 0;
                int tamamlanmayanProje = 0;
                int toplamProje = 0;
                foreach (var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {
                        toplamProje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            tamamlananProje++;
                        }
                        else
                        {
                            tamamlanmayanProje++;
                        }
                    }
                }
                tamamlanmisProjeSayisi[personel.PersonelBilgileriId] = tamamlananProje;
                tamamlanmayanProjeSayisi[personel.PersonelBilgileriId] = tamamlanmayanProje;
                toplamProjeSayisi[personel.PersonelBilgileriId] = toplamProje;
            }

            ViewBag.TamamlananProjeSayisi = tamamlanmisProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = tamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = toplamProjeSayisi;


            int projeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = projeSayisi;

            int personelSayisi = db.PersonelBilgileris.Count();
            ViewBag.PersonelSayisi = personelSayisi;

            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var basarisizVeYuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.BasarisizVeYuksek = basarisizVeYuksek;

            var basarisizVeOrta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.BasarisizVeOrta = basarisizVeOrta;

            var basarisizVeDusuk = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.BasarisizVeDusuk = basarisizVeDusuk;

            return View(personeller);
        }
    }
}