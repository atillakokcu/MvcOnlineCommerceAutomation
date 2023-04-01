using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommerceAutomation.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = context.Categorys.ToList().ToPagedList(sayfa, 4);
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

        public ActionResult Deneme()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(context.Categorys,"CategoryId","CategoryName");
            cs.Urunler = new SelectList(context.Products, "ProductId", "ProductName");
            return View(cs);
        }

        public JsonResult UrunGetir(int p)
        {
            var urunlistesi = (from x in context.Products
                               join y in context.Categorys
                               on x.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p 
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductId.ToString(),
                               }).ToList();

            return Json(urunlistesi,JsonRequestBehavior.AllowGet);

        }

    }
}