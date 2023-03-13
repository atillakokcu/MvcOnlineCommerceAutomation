using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [HttpGet]
        public ActionResult CariLogin1()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CariLogin1(Customer customers)
        {

            var bilgiler = context.Customers.FirstOrDefault(x => x.CustomerMail == customers.CustomerMail && x.CustomerPassword == customers.CustomerPassword);

            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CustomerMail, false);
                Session["CustomerMail"] = bilgiler.CustomerMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else 
            { 
                return RedirectToAction("Index","Login"); 
            }

        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = context.Admins.FirstOrDefault(x=>x.AdminName== admin.AdminName && x.AdminPassword==admin.AdminPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminName, false);
                Session["AdminName"]=bilgiler.AdminName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


            return View();
        }

    }
}