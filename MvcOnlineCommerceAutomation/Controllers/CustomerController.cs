using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context contex = new Context();
        public ActionResult Index()
        {
            var degerler = contex.Customers.Where(x => x.status == true).ToList();


            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Customer customer)
        {
           
            customer.status = true;
            contex.Customers.Add(customer);
            
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int Id)
        {
            var cari = contex.Customers.Find(Id);
            cari.status = false;
            contex.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult CariGetir(int id)
        {
            var cari = contex.Customers.Find(id);
            return View("CariGetir", cari);

        }

        public ActionResult CariGuncelle(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = (from data in contex.Customers where data.CustomerId == customer.CustomerId select data).FirstOrDefault();
            cari.CustomerName = customer.CustomerName;
            cari.CustomerMail = customer.CustomerMail;
            cari.CustomerSurname = customer.CustomerSurname;
            cari.CustomerCity = customer.CustomerCity;
            contex.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MusteriSatis(int Id)
        {
            var degerler = contex.SalesActions.Where(x => x.CustomerId == Id).ToList();
            var cr = contex.Customers.Where(z => z.CustomerId == Id).Select(y => y.CustomerName + "" + y.CustomerSurname).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);

        }



    }
}