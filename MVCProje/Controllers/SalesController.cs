using MVCProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStokEntities entities = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NeSales() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSales(TBLSATISLAR p)
        {
            entities.TBLSATISLAR.Add(p);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}