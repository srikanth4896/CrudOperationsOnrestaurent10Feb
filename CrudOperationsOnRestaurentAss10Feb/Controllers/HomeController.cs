using CrudOperationsOnRestaurentAss10Feb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOperationsOnRestaurentAss10Feb.Controllers
{
    public class HomeController : Controller
    {
        WFA3DotNetEntities db = new WFA3DotNetEntities();
        // GET: Home
        public ActionResult Index(string search="")
        {
           //var res = db.Restaurants.ToList();
            ViewBag.Search = search;
            var res = db.Restaurants.Where(e => e.Rname.Contains(search)).ToList();
            return View(res);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Restaurant re)
        {
            db.Restaurants.Add(re);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var restoUpadte = db.Restaurants.Where(e => e.Rid == id).FirstOrDefault();
            return View(restoUpadte);
        }
        [HttpPost]
        public ActionResult Update(Restaurant res)
        {
            var updateres = db.Restaurants.Where(e => e.Rid == res.Rid).FirstOrDefault();
            updateres.Rname = res.Rname;
            updateres.CusineType = res.CusineType;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deleteres =db.Restaurants.Where(e => e.Rid == id).FirstOrDefault();
            return View(deleteres);
        }
        [HttpPost]
        public ActionResult Delete(int id,Restaurant restaurant)
        {
            var delres = db.Restaurants.Where(e => e.Rid == id).FirstOrDefault();
            db.Restaurants.Remove(delres);
            return RedirectToAction("Index");
        }
        


    }
}