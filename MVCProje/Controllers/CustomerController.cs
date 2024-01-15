using MVCProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class CustomerController : Controller
    {
        MvcDbStokEntities entities = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = entities.TBLMUSTERILER.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(TBLMUSTERILER customer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCustomer");
            }
            entities.TBLMUSTERILER.Add(customer);
            customer.Durum = true;
            entities.SaveChanges();
            return View();
            //return RedirectToAction("Index");
        }
        public ActionResult PasifYap(int id) 
        {
            var item = entities.TBLMUSTERILER.Find(id);
            if(item != null) 
            {
                item.Durum = false;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult ActiveCustomer(int id)
        {
            var item = entities.TBLMUSTERILER.Find(id);
            if(item != null && item.Durum == false) 
            {
                item.Durum = true;
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        [HttpGet]

        public ActionResult UpdateCustomer(int id) 
        {
            var values = entities.TBLMUSTERILER.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(TBLMUSTERILER customer)
        {
            var values = entities.TBLMUSTERILER.Find(customer.MUSTERIID);
            values.MUSTERIAD = customer.MUSTERIAD;
            values.MUSTERISOYAD = customer.MUSTERISOYAD;
            values.Durum = customer.Durum;
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}