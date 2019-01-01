using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CosmeticApi.Models.Context;

namespace CosmeticApi.Controllers
{
    public class CountryController : ApiController
    {
        Context db = new Context();

        public HttpResponseMessage Get()
        {
            var country = db.Countries;
            var responce = Request.CreateResponse<IEnumerable<Country>>(HttpStatusCode.OK, country);
            return responce;
        }

        public HttpResponseMessage Get(int id)
        {
            var country = db.Countries.Find(id);
            var responce = Request.CreateResponse<Country>(HttpStatusCode.OK, country);
            return responce;
        }

        public void Post([FromBody]Country value)
        {
            db.Countries.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
            Country country = db.Countries.Find(id);
            if (country != null)
            {
                db.Countries.Remove(country);
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
