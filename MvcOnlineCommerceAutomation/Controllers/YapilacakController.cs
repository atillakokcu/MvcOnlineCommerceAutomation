
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context contex = new Context();
        public ActionResult Index()
        {
            var deger1 = contex.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = contex.Products.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = contex.Categorys.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 =(from x in contex.Customers select x.CustomerCity).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            

            var yapilacaklar = contex.Yapilacaks.ToList();
            return View(yapilacaklar);

        }
    }
}