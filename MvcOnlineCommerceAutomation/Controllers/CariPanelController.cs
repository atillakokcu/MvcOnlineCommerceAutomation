
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
    }
}