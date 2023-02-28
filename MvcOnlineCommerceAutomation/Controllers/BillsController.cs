using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class BillsController : Controller
    {
        // GET: Bills

        Context context = new Context();
        public ActionResult Index()
        {

            var Liste = context.Billss.ToList();
            return View(Liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Bills Bill)
        {
            context.Billss.Add(Bill);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Faturagetir(int Id)
        {
            var Fatura = context.Billss.Find(Id);

            return View("FaturaGetir",Fatura);

        }

        public ActionResult FaturaGuncelle(Bills FaturaGuncelleme)
        {
            var Fatura = context.Billss.Find(FaturaGuncelleme.BillId);
            Fatura.BillSerialNo= FaturaGuncelleme.BillSerialNo;
            Fatura.BillSiraNo= FaturaGuncelleme.BillSiraNo;
            Fatura.BillDate= FaturaGuncelleme.BillDate;
            Fatura.BillTime= FaturaGuncelleme.BillTime;
            Fatura.TeslimAlan= FaturaGuncelleme.TeslimAlan;
            Fatura.TeslimEden= FaturaGuncelleme.TeslimEden;
            Fatura.TaxOffice= FaturaGuncelleme.TaxOffice;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaDetay(int Id)
        {
            var degerler = context.InvoiceAdditionss.Where(x=>x.BillId==Id).ToList();

            return View(degerler);

        }
    }
}