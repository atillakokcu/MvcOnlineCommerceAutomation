using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;
namespace MvcOnlineCommerceAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context contex = new Context();
        public ActionResult Index()
        {
            var degerler = contex.Departments.Where(x => x.Status == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult DepartmanEkle(Department department)
        {
            contex.Departments.Add(department);
            department.Status = true;
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int Id)
        {
            var dpt = contex.Departments.Find(Id);
            dpt.Status = false;
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int Id)
        {
            var dpt = contex.Departments.Find(Id);
            return View("DepartmanGetir", dpt);
        }

        public ActionResult DepartmanGuncelle(Department department)
        {
            var dpt = (from data in contex.Departments where data.DepartmentId == department.DepartmentId select data).FirstOrDefault();
            dpt.DepartmentName = department.DepartmentName;
            dpt.Status = true;
            dpt.DepartmentId = department.DepartmentId;
            contex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int Id)
        {
            var degerler = contex.Employees.Where(x=>x.DepartmentId==Id).ToList();
            var dpt = contex.Departments.Where(x=>x.DepartmentId== Id).Select(y=>y.DepartmentName).FirstOrDefault();

            ViewBag.d = dpt;

            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int Id)
        {
            return View();

        }

    }


}