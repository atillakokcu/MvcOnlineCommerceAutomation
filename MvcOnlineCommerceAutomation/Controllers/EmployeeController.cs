﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context contex = new Context();
        public ActionResult Index()
        {
            var degerler = contex.Employees.ToList();

            return View(degerler);
        }


        [HttpGet]
        public ActionResult PersonelEkle()
        {

            List<SelectListItem> deger1 = (from x in contex.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                string Yol = "~/Image/" + DosyaAdi + Uzanti;
                Request.Files[0].SaveAs(Server.MapPath(Yol)); // resmi sunucu içerisindeki açtığımız klasorun içerisine kaydetme
                employee.EmployeeImage= "/Image/"+DosyaAdi + Uzanti;

            }
            contex.Employees.Add(employee);
            contex.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonelGetir(int Id)
        {
            List<SelectListItem> deger1 = (from x in contex.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            Employee personel = contex.Employees.Find(Id);

            return View("PersonelGetir",personel);

        }

        public ActionResult PersonelGuncelle(Employee Personel)
        {
            if (Request.Files.Count > 0)
            {
                string DosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string Uzanti = Path.GetExtension(Request.Files[0].FileName);
                string Yol = "~/Image/" + DosyaAdi + Uzanti;
                Request.Files[0].SaveAs(Server.MapPath(Yol)); // resmi sunucu içerisindeki açtığımız klasorun içerisine kaydetme
                Personel.EmployeeImage = "/Image/" + DosyaAdi + Uzanti;

            }
            var personel = contex.Employees.Find(Personel.EmployeeID);   
            personel.EmployeeName = Personel.EmployeeName;
            personel.EmployeeImage = Personel.EmployeeImage;
            personel.EmployeeSurname= Personel.EmployeeSurname;
            personel.DepartmentId= Personel.DepartmentId;
            contex.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelListe()
        {
            var sorgu = contex.Employees.ToList();
            return View(sorgu);
        }
    }
}