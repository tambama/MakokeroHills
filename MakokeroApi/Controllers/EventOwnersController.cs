using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MakokeroData;

namespace MakokeroApi.Controllers
{
    public class EventOwnersController : ApiController
    {
        private MakokeroContext db = new MakokeroContext();

        // GET: api/EventOwners
        public IQueryable<EventOwner> GetEventOwners()
        {
            return db.EventOwners;
        }

        // GET: api/EventOwners/5
        [ResponseType(typeof(EventOwner))]
        public async Task<IHttpActionResult> GetEventOwner(int id)
        {
            EventOwner eventOwner = await db.EventOwners.FindAsync(id);
            if (eventOwner == null)
            {
                return NotFound();
            }

            return Ok(eventOwner);
        }

        // PUT: api/EventOwners/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventOwner(int id, EventOwner eventOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventOwner.EventOwnerId)
            {
                return BadRequest();
            }

            db.Entry(eventOwner).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventOwnerExists(id))
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

        // POST: api/EventOwners
        [ResponseType(typeof(EventOwner))]
        public async Task<IHttpActionResult> PostEventOwner(EventOwner eventOwner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventOwners.Add(eventOwner);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventOwner.EventOwnerId }, eventOwner);
        }

        // DELETE: api/EventOwners/5
        [ResponseType(typeof(EventOwner))]
        public async Task<IHttpActionResult> DeleteEventOwner(int id)
        {
            EventOwner eventOwner = await db.EventOwners.FindAsync(id);
            if (eventOwner == null)
            {
                return NotFound();
            }

            db.EventOwners.Remove(eventOwner);
            await db.SaveChangesAsync();

            return Ok(eventOwner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventOwnerExists(int id)
        {
            return db.EventOwners.Count(e => e.EventOwnerId == id) > 0;
        }
    }
}