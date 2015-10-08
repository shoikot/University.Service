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
    public class CourseScedulesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CourseScedules
        public IQueryable<CourseScedule> GetCourseScedules()
        {
            return db.CourseScedules;
        }

        // GET: api/CourseScedules/5
        [ResponseType(typeof(CourseScedule))]
        public async Task<IHttpActionResult> GetCourseScedule(int id)
        {
            CourseScedule courseScedule = await db.CourseScedules.FindAsync(id);
            if (courseScedule == null)
            {
                return NotFound();
            }

            return Ok(courseScedule);
        }

        // PUT: api/CourseScedules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCourseScedule(int id, CourseScedule courseScedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseScedule.CourseSceduleId)
            {
                return BadRequest();
            }

            db.Entry(courseScedule).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseSceduleExists(id))
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

        // POST: api/CourseScedules
        [ResponseType(typeof(CourseScedule))]
        public async Task<IHttpActionResult> PostCourseScedule(CourseScedule courseScedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseScedules.Add(courseScedule);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = courseScedule.CourseSceduleId }, courseScedule);
        }

        // DELETE: api/CourseScedules/5
        [ResponseType(typeof(CourseScedule))]
        public async Task<IHttpActionResult> DeleteCourseScedule(int id)
        {
            CourseScedule courseScedule = await db.CourseScedules.FindAsync(id);
            if (courseScedule == null)
            {
                return NotFound();
            }

            db.CourseScedules.Remove(courseScedule);
            await db.SaveChangesAsync();

            return Ok(courseScedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseSceduleExists(int id)
        {
            return db.CourseScedules.Count(e => e.CourseSceduleId == id) > 0;
        }
    }
}