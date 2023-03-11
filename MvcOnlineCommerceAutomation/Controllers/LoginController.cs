using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class LoginController : Controller
    {

        Context context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {


            return PartialView();
        }


        [HttpPost]
        public PartialViewResult Partial1(Customer customer)
        {
            context.Customers.Add(customer);
            customer.status = true;
            context.SaveChanges();
            return PartialView();

        }

    }
}