using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRTIDataAPI.Models;

namespace CRTIDataAPI.Controllers
{
    public class UsersController : ApiController
    {
        private TimeMasterEntities db = new TimeMasterEntities();

        public Wrapper<User> GetUser(string id)
        {
            var queryResults = db.sp_GetUser1(id);
            if (queryResults == null)
            {
                return new Wrapper<User>
                {
                    Status = "Error",
                    Users = null
                };
            }
            return new Wrapper<User>
            {
                Status = "OK",
                Users = queryResults
            };
 
        }


        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(string id, User users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UserID)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.sp_UpdateUser(users.UserID,users.UserName,users.Password,users.Email, users.isAdmin);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUsers(User users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sp_AddNewUser(users.UserID, users.UserName, users.Password, users.Email, users.isAdmin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = users.UserID }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUsers(string id)
        {
            User users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(string id)
        {
            return db.Users.Count(e => e.UserID == id) > 0;
        }

        public class Wrapper<T>
        {
            public string Status { get; set; }
            public ObjectResult<sp_GetUser_Result> Users { get; set; }
        }
    }
}