using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class ProductController : Controller
    {
        Context contex = new Context();
        // GET: Product
        public ActionResult Index(string p)
        {
            var Urunler = from x in contex.Products select x;

            if (!string.IsNullOrEmpty(p))
            {
                Urunler = Urunler.Where(y => y.ProductName.Contains(p));
            }
            return View(Urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in contex.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Product Urun)
        {
            contex.Products.Add(Urun);
            contex.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult UrunSil(int Id)
        {
            var deger = contex.Products.Find(Id);
            deger.Status = false;
            contex.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunGetir(int Id)
        {

            List<SelectListItem> deger1 = (from x in contex.Categorys.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;


            var urundeger = contex.Products.Find(Id);

            return View("UrunGetir", urundeger);

        }

        public ActionResult UrunGuncelle(Product Urun)
        {
            var Urn = contex.Products.Find(Urun.ProductId);
            Urn.Status = true;
            Urn.ProductBrand = Urun.ProductBrand;
            Urn.ProductStock = Urun.ProductStock;
            Urn.ProductPurchasePrice = Urun.ProductPurchasePrice;
            Urn.ProductSalePrice = Urun.ProductSalePrice;
            Urn.CategoryId = Urun.CategoryId;
            Urn.ProductId = Urun.ProductId;
            Urn.ProductImage = Urun.ProductImage;
            contex.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = contex.Products.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult SatisYap(int Id)
        {
            List<SelectListItem> deger3 = (from x in contex.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString(),
                                           }).ToList();

            ViewBag.dgr3 = deger3;

            var deger1 = contex.Products.Find(Id);
            ViewBag.dgr1 = deger1.ProductId;
            ViewBag.dgr2 = deger1.ProductPurchasePrice;

            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SalesAction salesaction)
        {
            salesaction.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            contex.SalesActions.Add(salesaction);
            contex.SaveChanges();
            return RedirectToAction("Index","Sales");

            
        }
    }
}