using MVCProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ProductsDefaultController : Controller
    {
        MvcDbStokEntities enties = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = enties.TBLURUNLER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProducts()
        {
            List<SelectListItem> values = (from x in enties.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString(),

                                           }).ToList();
            ViewBag.value = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddProducts(TBLURUNLER products)
        {
            var ktg = enties.TBLKATEGORI.Where(x => x.KATEGORIID == products.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            products.TBLKATEGORI = ktg;
            enties.TBLURUNLER.Add(products);
            enties.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProducts(int id) 
        {
            var value = enties.TBLURUNLER.Find(id);
            enties.TBLURUNLER.Remove(value);
            enties.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifYap(int id)
        {
            var item = enties.TBLURUNLER.Find(id);

            if (item != null)
            {
                item.Durum = false;
                enties.SaveChanges();

                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        [HttpGet]
        public ActionResult UpdateProducts(int id) 
        {
            List<SelectListItem> values = (from x in enties.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString(),

                                           }).ToList();
            ViewBag.value = values;
            var valuess = enties.TBLURUNLER.Find(id);

           return View(valuess);
        }

        [HttpPost]

        public ActionResult UpdateProducts(TBLURUNLER products)
        {
            var values = enties.TBLURUNLER.Find(products.URUNID);
            values.URUNAD = products.URUNAD;
            values.URUNKATEGORI = products.URUNKATEGORI;
            values.URUNFIYAT = products.URUNFIYAT;
            values.MARKA = products.MARKA;
            values.STOK = products.STOK;
            values.Durum = products.Durum;

            enties.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}