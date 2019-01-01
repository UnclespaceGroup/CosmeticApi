using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CosmeticApi.Models.Context;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace CosmeticApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReviewsController : ApiController
    {
        Context db = new Context();

        public HttpResponseMessage Get()
        {
            var reviews = db.Reviews.Include(p => p.Brand).Include(p => p.User.Name).Include(p => p.Comments);
            var responce = Request.CreateResponse<IEnumerable<Review>>(HttpStatusCode.OK, reviews);
            return responce;
        }

        public HttpResponseMessage Get(int id)
        {
            var review = db.Reviews.Find(id);
            var responce = Request.CreateResponse<Review>(HttpStatusCode.OK, review);
            return responce;
        }

        public void Post([FromBody]Review value)
        {
            db.Reviews.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, [FromBody]Review value)
        {
            var review = db.Reviews.Find(id);
            if (review != null)
            {
                review.Active = review.Active ? false : true;
                if (value.Title != null) review.Title = value.Title;
                if (value.Text != null) review.Text = value.Text;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
            {
                db.Reviews.Remove(review);
                db.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
