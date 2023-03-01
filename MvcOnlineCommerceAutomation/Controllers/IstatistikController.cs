using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var deger1=contex.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = contex.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = contex.Employees.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = contex.Categorys.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = contex.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.d5 = deger5;

            var deger7 = contex.Products.Count(x => x.ProductStock<=20).ToString();
            ViewBag.d7 = deger7;
            return View();
        }
    }
}