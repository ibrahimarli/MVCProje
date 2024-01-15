using MVCProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class CategoryController : Controller
    {
        MvcDbStokEntities entities = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = entities.TBLKATEGORI.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TBLKATEGORI category) 
        {
            if(!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            entities.TBLKATEGORI.Add(category);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id) 
        {
            var value = entities.TBLKATEGORI.Find(id);
            entities.TBLKATEGORI.Remove(value);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = entities.TBLKATEGORI.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TBLKATEGORI category)
        {
            var value = entities.TBLKATEGORI.Find(category.KATEGORIID);
            value.KATEGORIAD = category.KATEGORIAD;
            value.Durum = category.Durum;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PasifYap(int id)
        {
            var item = entities.TBLKATEGORI.Find(id);

            if (item != null)
            {
                item.Durum = false;
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult ActivateUser(int id)
        {
            var item = entities.TBLKATEGORI.Find(id);
            if (item != null && item.Durum == false) 
            {
                item.Durum = true;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}