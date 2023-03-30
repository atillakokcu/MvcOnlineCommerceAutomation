
using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Security;

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
            var degerler = context.Customers.Where(x=>x.CustomerMail== Mail).ToList();
            ViewBag.m = Mail;
            var MailId = context.Customers.Where(x=>x.CustomerMail ==Mail).Select(y=>y.CustomerId).FirstOrDefault();
            ViewBag.mid = MailId;
            var toplamsatis = context.SalesActions.Where(x => x.CustomerId == MailId).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = context.SalesActions.Where(x => x.CustomerId == MailId).Sum(y => y.TotalAmount);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi = context.SalesActions.Where(x => x.CustomerId == MailId).Sum(y => y.Piece);
            ViewBag.toplamurunsayisi = toplamurunsayisi;

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

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var Mail = (string)Session["CustomerMail"];
            var Mesajlar = context.Mesajlars.Where(x => x.Alici == Mail).OrderByDescending(x=>x.MesajId).ToList();
            var GelenMesajSayisi= context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            ViewBag.d2 = GidenMesajSayisi;

            return View(Mesajlar);
        }

        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var Mail = (string)Session["CustomerMail"];
            var Mesajlar = context.Mesajlars.Where(x => x.Gonderici == Mail).OrderByDescending(x => x.MesajId).ToList();
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            var GelenMesajSayisi = context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            ViewBag.d2 = GidenMesajSayisi;
            return View(Mesajlar);
        }

        [Authorize]
        public ActionResult MesajDetay(int Id)
        {
            var degerler = context.Mesajlars.Where(x=>x.MesajId== Id).ToList();
            var Mail = (string)Session["CustomerMail"];
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            var GelenMesajSayisi = context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            ViewBag.d2 = GidenMesajSayisi;
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var Mail = (string)Session["CustomerMail"];
            var GidenMesajSayisi = context.Mesajlars.Count(x => x.Gonderici == Mail).ToString();
            var GelenMesajSayisi = context.Mesajlars.Count(x => x.Alici == Mail).ToString();
            ViewBag.d1 = GelenMesajSayisi;
            ViewBag.d2 = GidenMesajSayisi;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesajlar)
        {
            var Mail = (string)Session["CustomerMail"];
            mesajlar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesajlar.Gonderici= Mail;
            context.Mesajlars.Add(mesajlar);
            context.SaveChanges();
            return View();
        }

        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var kargotakipno = from x in context.KargoDetays select x;

            if (!string.IsNullOrEmpty(p))
            {
                kargotakipno = kargotakipno.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargotakipno.ToList());
        }

        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");


        }

    }
}