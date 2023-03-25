
using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
       Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var Mail = (string)Session["CustomerMail"];
            var degerler = context.Customers.FirstOrDefault(x=>x.CustomerMail== Mail);
            ViewBag.m = Mail;
            return View(degerler);
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var Mail = (string)Session["CustomerMail"];
            var Id=context.Customers.Where(x=>x.CustomerMail== Mail.ToString()).Select(y=>y.CustomerId).FirstOrDefault();
            var degerler = context.SalesActions.Where(x=>x.CustomerId==Id).ToList();
            return View(degerler);
        }

        public ActionResult GelenMesajlar()
        {
            var Mail = (string)Session["CustomerMail"];
            var Mesajlar = context.Mesajlars.Where(x => x.Alici == Mail).ToList();
            var GelenMesajSayisi= context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            ViewBag.d2 = GidenMesajSayisi;

            return View(Mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var Mail = (string)Session["CustomerMail"];
            var Mesajlar = context.Mesajlars.Where(x => x.Gonderici == Mail).ToList();
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            var GelenMesajSayisi = context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            ViewBag.d2 = GidenMesajSayisi;
            return View(Mesajlar);
        }

        //[HttpGet]
        //public ActionResult YeniMesaj()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult YeniMesaj()
        //{

        //    return View();
        //}
    }
}