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
    public class TeacherCoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TeacherCourses
        public IQueryable<TeacherCourse> GetTeacherCourses()
        {
            return db.TeacherCourses;
        }

        // GET: api/TeacherCourses/5
        [ResponseType(typeof(TeacherCourse))]
        public async Task<IHttpActionResult> GetTeacherCourse(int id)
        {
            TeacherCourse teacherCourse = await db.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            return Ok(teacherCourse);
        }

        // PUT: api/TeacherCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeacherCourse(int id, TeacherCourse teacherCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacherCourse.TeacherCourseId)
            {
                return BadRequest();
            }

            db.Entry(teacherCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherCourseExists(id))
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

        // POST: api/TeacherCourses
        [ResponseType(typeof(TeacherCourse))]
        public async Task<IHttpActionResult> PostTeacherCourse(TeacherCourse teacherCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TeacherCourses.Add(teacherCourse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teacherCourse.TeacherCourseId }, teacherCourse);
        }

        // DELETE: api/TeacherCourses/5
        [ResponseType(typeof(TeacherCourse))]
        public async Task<IHttpActionResult> DeleteTeacherCourse(int id)
        {
            TeacherCourse teacherCourse = await db.TeacherCourses.FindAsync(id);
            if (teacherCourse == null)
            {
                return NotFound();
            }

            db.TeacherCourses.Remove(teacherCourse);
            await db.SaveChangesAsync();

            return Ok(teacherCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeacherCourseExists(int id)
        {
            return db.TeacherCourses.Count(e => e.TeacherCourseId == id) > 0;
        }
    }
}