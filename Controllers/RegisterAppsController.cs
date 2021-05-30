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
    public class RegisterAppsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RegisterApps
        public IQueryable<RegisterApp> GetRegisterApps()
        {
            return db.RegisterApps;
        }

        // GET: api/RegisterApps/5
        [ResponseType(typeof(RegisterApp))]
        public IHttpActionResult GetRegisterApp(int id)
        {
            RegisterApp registerApp = db.RegisterApps.Find(id);
            if (registerApp == null)
            {
                return NotFound();
            }

            return Ok(registerApp);
        }

        // PUT: api/RegisterApps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegisterApp(int id, RegisterApp registerApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registerApp.Id)
            {
                return BadRequest();
            }

            db.Entry(registerApp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterAppExists(id))
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

        // POST: api/RegisterApps
        [ResponseType(typeof(RegisterApp))]
        public IHttpActionResult PostRegisterApp(RegisterApp registerApp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RegisterApps.Add(registerApp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = registerApp.Id }, registerApp);
        }

        // DELETE: api/RegisterApps/5
        [ResponseType(typeof(RegisterApp))]
        public IHttpActionResult DeleteRegisterApp(int id)
        {
            RegisterApp registerApp = db.RegisterApps.Find(id);
            if (registerApp == null)
            {
                return NotFound();
            }

            db.RegisterApps.Remove(registerApp);
            db.SaveChanges();

            return Ok(registerApp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegisterAppExists(int id)
        {
            return db.RegisterApps.Count(e => e.Id == id) > 0;
        }
    }
}