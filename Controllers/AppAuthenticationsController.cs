using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _3LineCardMgtLimited.DAL;
using _3LineCardMgtLimited.Models;

namespace _3LineCardMgtLimited.Controllers
{
    public class AppAuthenticationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppAuthentications
        public IQueryable<AppAuthentication> GetAppAuthentications()
        {
            return db.AppAuthentications;
        }

        // GET: api/AppAuthentications/5
        [ResponseType(typeof(AppAuthentication))]
        public IHttpActionResult GetAppAuthentication(int id)
        {
            AppAuthentication appAuthentication = db.AppAuthentications.Find(id);
            if (appAuthentication == null)
            {
                return NotFound();
            }

            return Ok(appAuthentication);
        }

        // PUT: api/AppAuthentications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppAuthentication(int id, AppAuthentication appAuthentication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appAuthentication.Id)
            {
                return BadRequest();
            }

            db.Entry(appAuthentication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppAuthenticationExists(id))
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

        // POST: api/AppAuthentications
        [ResponseType(typeof(AppAuthentication))]
        public IHttpActionResult PostAppAuthentication(AppAuthentication appAuthentication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppAuthentications.Add(appAuthentication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appAuthentication.Id }, appAuthentication);
        }

        // DELETE: api/AppAuthentications/5
        [ResponseType(typeof(AppAuthentication))]
        public IHttpActionResult DeleteAppAuthentication(int id)
        {
            AppAuthentication appAuthentication = db.AppAuthentications.Find(id);
            if (appAuthentication == null)
            {
                return NotFound();
            }

            db.AppAuthentications.Remove(appAuthentication);
            db.SaveChanges();

            return Ok(appAuthentication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppAuthenticationExists(int id)
        {
            return db.AppAuthentications.Count(e => e.Id == id) > 0;
        }
    }
}