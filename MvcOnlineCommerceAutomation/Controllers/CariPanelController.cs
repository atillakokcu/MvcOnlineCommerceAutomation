
using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var degerler = context.Customers.FirstOrDefault(x=>x.CustomerMail== Mail);
            ViewBag.m = Mail;
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
    }
}