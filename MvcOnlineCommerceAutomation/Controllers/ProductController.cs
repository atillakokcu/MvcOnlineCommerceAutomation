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
        public ActionResult Index()
        {
            var Urunler = contex.Products.ToList();
            return View(Urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();


        }

        [HttpPost]
        public ActionResult YeniUrun(Product Urun)
        {
            contex.Products.Add(Urun);
            contex.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}