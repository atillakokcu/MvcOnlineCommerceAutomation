using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context contex = new Context();
        public ActionResult Index(string p)
        {
            var kargotakipno = from x in contex.KargoDetays select x;

            if (!string.IsNullOrEmpty(p))
            {
                kargotakipno = kargotakipno.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargotakipno.ToList());
            
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K" };
            int k1, k2, k3;
            k1 = random.Next(0, karakterler.Length);
            k2 = random.Next(0, karakterler.Length);
            k3 = random.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);

            string Kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = Kod;
            return View();
        }


        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargodetay)
        {
            contex.KargoDetays.Add(kargodetay);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string Id)
        {
            var degerler = contex.KargoTakips.Where(x => x.TakipKodu == Id).ToList();
            

            return View(degerler);
        }


    }
}