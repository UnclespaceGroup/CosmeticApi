using CosmeticApi.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CosmeticApi.Controllers
{
    public class ManageController : Controller
    {
        Context db = new Context();
        
        public ActionResult Index()
        {
            IEnumerable<Review> reviews = db.Reviews.Include(p => p.Brand).Include(p => p.Comments).Include(p => p.User);
            return View(reviews);
        }
        public ActionResult Country()
        {
            IEnumerable<Country> countries = db.Countries;
            return PartialView(countries);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}