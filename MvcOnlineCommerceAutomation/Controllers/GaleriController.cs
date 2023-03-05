using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Products.ToList();
            return View(degerler);
        }
    }
}