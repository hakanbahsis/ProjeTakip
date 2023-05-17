using ProjeTakip.Models.DataContext;
using ProjeTakip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeTakip.Controllers
{
    public class ProjeRaporlariController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext();  //VERİ TABANI BAĞLANTISI

        public ActionResult TamamalanmisOncelikGruplari()
        {
            return View();
        }

        public ActionResult VisualizeSTamamlanmisDurumGruplari()
        {
            return Json(OncelikGrupTİpi(), JsonRequestBehavior.AllowGet);
        }

        public List<OncelikDurumAnaliz> OncelikGrupTİpi()
        {
            
            List<OncelikDurumAnaliz> snf = new List<OncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())

                snf = c.PersonelProjeleris.Where(x => x.TamamlanmaDurumu == true).GroupBy(p => p.OncelikDurumu).Select(x => new OncelikDurumAnaliz
                {

                    onceliktipi = x.Key,
                    oncelikadeti = x.Count(),
                }).ToList();

            return snf;
        }




        public ActionResult TamamalanmamisOncelikGruplari()
        {
            return View();
        }

        public ActionResult VisualizeTamamlanmayanDurumruplari()
        {
            return Json(OncelikTamamlanmisGrupTİpi(), JsonRequestBehavior.AllowGet);
        }

        public List<OncelikDurumAnaliz> OncelikTamamlanmisGrupTİpi()
        {
            ;
            List<OncelikDurumAnaliz> snf = new List<OncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())

                snf = c.PersonelProjeleris.Where(x => x.TamamlanmaDurumu == false).GroupBy(p => p.OncelikDurumu).Select(x => new OncelikDurumAnaliz
                {

                    onceliktipi = x.Key,
                    oncelikadeti = x.Count(),
                }).ToList();

            return snf;
        }


        public ActionResult GenelProjeRaporlari()
        {
            return View();
        }


        public ActionResult CanliDestek()
        {
            var destek = db.PersonelBilgileris.Where(x => x.Departman == "Yönetim");
            return View(destek.ToList());
        }
    }
}