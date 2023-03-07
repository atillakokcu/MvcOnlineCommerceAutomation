using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class IstatistikController : Controller
    {
        Context contex = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = contex.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = contex.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = contex.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = contex.Categorys.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = contex.Products.Sum(x => x.ProductStock).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in contex.Products select x.ProductBrand).Distinct().Count(); // distinc listedeki elemanları tekrarsız getirmeye yarıyor.
            ViewBag.d6 = deger6;
            var deger7 = contex.Products.Count(x => x.ProductStock <= 20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from data in contex.Products orderby data.ProductSalePrice descending select data.ProductName).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from data in contex.Products orderby data.ProductSalePrice ascending select data.ProductName).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = contex.Products.Count(x => x.ProductName == "Buzdolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = contex.Products.Count(x => x.ProductName == "bilgisayar").ToString();
            ViewBag.d11 = deger11;

            var deger12 = contex.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault(); // orderbydescetin isme göre tersten sıralama  // key ise guruplandırğım şeyin ismi yani marka
            ViewBag.d12 = deger12;

            var deger13 =contex.Products.Where(u=>u.ProductId== (contex.SalesActions.GroupBy(x=>x.ProductId).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = contex.SalesActions.Sum(x => x.TotalAmount).ToString();
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = contex.SalesActions.Count(x => x.Date == bugun).ToString();
            ViewBag.d15 = deger15;
            
            try
            {
                var deger16 = (from data in contex.SalesActions where data.Date == bugun select data).Sum(x => x.TotalAmount);
            }
            catch (Exception)
            {

                ViewBag.d16 = 0;
            }
            
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = (from x in contex.Customers
                         group x by x.CustomerCity into g
                         select new SinifGrup
                         {
                             Sehir = g.Key,
                             Sayi=g.Count(),
                         });
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = (from x in contex.Employees
                          group x by x.Departments.DepartmentName into g
                          select new SinifGrup2
                          {
                              Departman = g.Key,
                              Sayi = g.Count(),
                          });
            return PartialView(sorgu2.ToList());
        }


        public PartialViewResult Partial2()
        {
            var sorgu = contex.Customers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = contex.Products.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu3 = (from x in contex.Products
                         group x by x.ProductBrand into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count(),
                         });
            return PartialView(sorgu3.ToList());
        }


    }

    
}