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
using University.Service.Areas.HelpPage.Models;
using University.Service.Models;

namespace University.Service.Areas.HelpPage.Controllers
{
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Attendences
        public IQueryable<Attendence> GetAttendences()
        {
            return db.Attendences;
        }

        // GET: api/Attendences/5
        [ResponseType(typeof(Attendence))]
        public async Task<IHttpActionResult> GetAttendence(int id)
        {
            Attendence attendence = await db.Attendences.FindAsync(id);
            if (attendence == null)
            {
                return NotFound();
            }

            return Ok(attendence);
        }

        // PUT: api/Attendences/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAttendence(int id, Attendence attendence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendence.AttendenceId)
            {
                return BadRequest();
            }

            db.Entry(attendence).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendenceExists(id))
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

        // POST: api/Attendences
        [ResponseType(typeof(Attendence))]
        public async Task<IHttpActionResult> PostAttendence(Attendence attendence)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attendences.Add(attendence);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = attendence.AttendenceId }, attendence);
        }

        // DELETE: api/Attendences/5
        [ResponseType(typeof(Attendence))]
        public async Task<IHttpActionResult> DeleteAttendence(int id)
        {
            Attendence attendence = await db.Attendences.FindAsync(id);
            if (attendence == null)
            {
                return NotFound();
            }

            db.Attendences.Remove(attendence);
            await db.SaveChangesAsync();

            return Ok(attendence);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttendenceExists(int id)
        {
            return db.Attendences.Count(e => e.AttendenceId == id) > 0;
        }
    }
}