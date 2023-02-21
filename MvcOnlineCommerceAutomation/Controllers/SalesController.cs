using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context contex = new Context();
        public ActionResult Index()
        {
            var degerler = contex.SalesActions.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in contex.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString(),
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in contex.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerId.ToString(),
                                           }).ToList();


            List<SelectListItem> deger3 = (from x in contex.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName + " " + x.EmployeeSurname,
                                               Value = x.EmployeeID.ToString(),
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;


            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SalesAction sales)
        {
            contex.SalesActions.Add(sales);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}