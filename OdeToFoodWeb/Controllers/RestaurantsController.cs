using OdeToFoodData.Models;
using OdeToFoodData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        //GET
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant) 
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
            
        }
    }
}