﻿using MvcOnlineCommerceAutomation.Models.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Management;
using System.Web.Mvc;

namespace MvcOnlineCommerceAutomation.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context contex = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori- Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
                xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 88 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = contex.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.ProductStock));
            var grafik = new Chart(800, 800).AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index4()
        {

            return View();
        }

        public ActionResult VisualizeUrunResult()
        {

            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> Urunlistesi()
        {

            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                UrunAd = "bilgisayar",
                Stok = 120
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "beyaz eşya",
                Stok = 150
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "mobilya",
                Stok = 70
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "küçük ev aletleri",
                Stok = 180
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "mobil cihazlar",
                Stok = 90
            });

            return snf;
        }

        public ActionResult Index5()
        {

            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {

            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var contex = new Context())
            {
                snf = contex.Products.Select(x => new Sinif2
                {
                    urn = x.ProductName,
                    stk = x.ProductStock
                }).ToList();

            }

            return snf;

        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }

    }
}