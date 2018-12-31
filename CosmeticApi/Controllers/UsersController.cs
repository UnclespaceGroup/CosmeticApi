using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CosmeticApi.Models.Context;

namespace CosmeticApi.Controllers
{
    public class UsersController : ApiController
    {
        Context db = new Context();

        public HttpResponseMessage Get()
        {
            var users = db.Users;
            var responce = Request.CreateResponse<IEnumerable<User>>(HttpStatusCode.OK, users);
            return responce;
        }

        public HttpResponseMessage Get(int id)
        {
            var user = db.Users.Find(id);
            var responce = Request.CreateResponse<User>(HttpStatusCode.OK, user);
            return responce;
        }

        public void Post([FromBody]User value)
        {
            db.Users.Add(value);
            db.SaveChanges();
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
