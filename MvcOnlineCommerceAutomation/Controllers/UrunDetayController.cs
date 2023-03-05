using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        Context contex = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            //var degerler = contex.Products.Where(x=>x.ProductId ==1).ToList();
            
            cs.Deger1=contex.Products.Where(x=>x.ProductId==2).ToList();
            cs.Deger2=contex.Detays.Where(x => x.DetayId == 2).ToList();
            return View(cs);
        }
    }
}