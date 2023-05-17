using ProjeTakip.Models.DataContext;
using ProjeTakip.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeTakip.Controllers
{
    public class PersonelProjeleriController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext(); 
        // GET: PersonelProjeleri
        public ActionResult Index()
        {
            var projeListele = db.PersonelProjeleris.ToList();
            return View(projeListele);
        }
        public ActionResult Create()
        {
            ViewBag.PersonelBilgileriId = new SelectList(db.PersonelBilgileris, "PersonelBilgileriId", "AdSoyad");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PersonelProjeleri projeObj, int[] personelBilgileriId)
        {
            foreach (var item in personelBilgileriId)
            {
                projeObj.PersonelBilgileris.Add(db.PersonelBilgileris.Find(item));
            }
            projeObj.OlusturmaTarihi = DateTime.Now;
            db.PersonelProjeleris.Add(projeObj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            return View(projeObj);
        }

        [HttpPost]
        public ActionResult Edit(PersonelProjeleri personelProjeleri)
        {
            var projeDbObj = db.PersonelProjeleris.Find(personelProjeleri.PersonelProjeId);
            projeDbObj.ProjeAciklama = personelProjeleri.ProjeAciklama;
            projeDbObj.ProjeBaslik = personelProjeleri.ProjeBaslik;
            projeDbObj.TamamlanmaOrani = personelProjeleri.TamamlanmaOrani;
            projeDbObj.OncelikDurumu = personelProjeleri.OncelikDurumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tamamla(int id)
        {
            var projeObj = db.PersonelProjeleris.Find(id);
            projeObj.TamamlanmaDurumu = true;
            projeObj.TamamlanmaOrani = 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}