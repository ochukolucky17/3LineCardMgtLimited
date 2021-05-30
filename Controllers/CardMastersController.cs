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
    public class CardMastersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CardMasters
        public IQueryable<CardMaster> GetcardMasters()
        {
            return db.cardMasters;
        }

        // GET: api/CardMasters/5
        [ResponseType(typeof(CardMaster))]
        public IHttpActionResult GetCardMaster(int id)
        {
            CardMaster cardMaster = db.cardMasters.Find(id);
            if (cardMaster == null)
            {
                return NotFound();
            }

            return Ok(cardMaster);
        }

        // verifiedCard: api/CardMasters
        public IQueryable<CardMaster> verifiedCardMasters()
        {
            return db.cardMasters;
        }
        

        // verifiedCard: api/CardMasters/5
        [ResponseType(typeof(CardMaster))]
        public IHttpActionResult verifiedCardMaster(string cardNumber)
        {
            CardMaster cardMaster = db.cardMasters.Find(cardNumber);
            if (cardMaster == null)
            {
                return NotFound();
            }
            // if not found

            cardMaster.hitCount = cardMaster.hitCount + 1;
            db.Entry(cardMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardNumberExists(cardNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cardMaster);
        }
        // PUT: api/CardMasters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCardMaster(int id, CardMaster cardMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cardMaster.Id)
            {
                return BadRequest();
            }
          

            db.Entry(cardMaster).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardMasterExists(id))
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

        // POST: api/CardMasters
        [ResponseType(typeof(CardMaster))]
        public IHttpActionResult PostCardMaster(CardMaster cardMaster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cardMasters.Add(cardMaster);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cardMaster.Id }, cardMaster);
        }

        // DELETE: api/CardMasters/5
        [ResponseType(typeof(CardMaster))]
        public IHttpActionResult DeleteCardMaster(int id)
        {
            CardMaster cardMaster = db.cardMasters.Find(id);
            if (cardMaster == null)
            {
                return NotFound();
            }

            db.cardMasters.Remove(cardMaster);
            db.SaveChanges();

            return Ok(cardMaster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CardMasterExists(int id)
        {
            return db.cardMasters.Count(e => e.Id == id) > 0;
        }
        private bool CardNumberExists(string cardNumber)
        {
            return db.cardMasters.Count(e => e.cardNumber == cardNumber) > 0;
        }
    }
}