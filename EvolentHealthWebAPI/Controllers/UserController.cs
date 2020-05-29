using EvolentHealthWebAPI.Database;
using EvolentHealthWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EvolentHealthWebAPI.Controllers
{
    public class UserController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        //api/user
        public IEnumerable<UserContact> GetUsers()
        {
            return db.Contacts.ToList();
        }

        //api/user/id
        public UserContact GetUser(int id)
        {
            return db.Contacts.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddUser(UserContact model)
        {
            try
            {
                db.Contacts.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpPut]
        public HttpResponseMessage UpdateUser(int id, UserContact model)
        {
            try
            {
                if (id == model.UserID)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }

            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                UserContact user = db.Contacts.Find(id);
                if (user != null)
                {
                    db.Contacts.Remove(user);
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return response;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }
    }
}
