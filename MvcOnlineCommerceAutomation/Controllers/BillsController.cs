using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    [AllowAnonymous]
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

            return View("FaturaGetir", Fatura);

        }

        public ActionResult FaturaGuncelle(Bills FaturaGuncelleme)
        {
            var Fatura = context.Billss.Find(FaturaGuncelleme.BillId);
            Fatura.BillSerialNo = FaturaGuncelleme.BillSerialNo;
            Fatura.BillSiraNo = FaturaGuncelleme.BillSiraNo;
            Fatura.BillDate = FaturaGuncelleme.BillDate;
            Fatura.BillTime = FaturaGuncelleme.BillTime;
            Fatura.TeslimAlan = FaturaGuncelleme.TeslimAlan;
            Fatura.TeslimEden = FaturaGuncelleme.TeslimEden;
            Fatura.TaxOffice = FaturaGuncelleme.TaxOffice;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FaturaDetay(int Id)
        {
            var degerler = context.InvoiceAdditionss.Where(x => x.BillId == Id).ToList();

            return View(degerler);

        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKalem(InvoiceAdditions FaturaKalem)
        {
            context.InvoiceAdditionss.Add(FaturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = context.Billss.ToList();
            cs.deger2 = context.InvoiceAdditionss.ToList();
            return View(cs);

        }

        public ActionResult FaturaKaydet(string BillSerialNo, string BillSiraNo, DateTime BillDate, string TaxOffice, string BillTime, string TeslimEden, string TeslimAlan, string Toplam, InvoiceAdditions[] kalemler)
        {
            Bills f = new Bills();
            f.BillSerialNo= BillSerialNo;
            f.BillSiraNo = BillSiraNo;
            f.BillDate = BillDate;
            f.BillTime = BillTime;
            f.TaxOffice = TaxOffice;
            f.TeslimAlan= TeslimAlan;
            f.TeslimEden= TeslimEden;
            f.Toplam = decimal.Parse(Toplam);
            context.Billss.Add(f);
            foreach(var x in kalemler)
            {
                InvoiceAdditions fk = new InvoiceAdditions();
                fk.InvoiceDescription = x.InvoiceDescription;
                fk.InvoiceUnitPrice= x.InvoiceUnitPrice;
                fk.BillId= x.BillId;
                fk.InvoiceAmount= x.InvoiceAmount;
                fk.InvoiceTotalPrice= x.InvoiceTotalPrice;
                context.InvoiceAdditionss.Add(fk);
            }
            context.SaveChanges();
            return Json("işlem başarılı",JsonRequestBehavior.AllowGet);

        }

    }
}