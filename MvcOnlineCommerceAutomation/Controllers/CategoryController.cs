using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Categorys.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {

            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category k)
        {
            context.Categorys.Add(k);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int Id)
        {
            var ktg = context.Categorys.Find(Id);
            context.Categorys.Remove(ktg);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int Id)
        {
            var kategori = context.Categorys.Find(Id);
            return View("KategoriGetir", kategori);


        }

        public ActionResult KategoriGuncelle(Category k)
        {
            var ktg = context.Categorys.Find(k.CategoryId);
            ktg.CategoryName= k.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}