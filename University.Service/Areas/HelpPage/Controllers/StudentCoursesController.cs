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
    public class StudentCoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StudentCourses
        public IQueryable<StudentCourse> GetStudentCourses()
        {
            return db.StudentCourses;
        }

        // GET: api/StudentCourses/5
        [ResponseType(typeof(StudentCourse))]
        public async Task<IHttpActionResult> GetStudentCourse(int id)
        {
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return Ok(studentCourse);
        }

        // PUT: api/StudentCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentCourse(int id, StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentCourse.StudentCourseId)
            {
                return BadRequest();
            }

            db.Entry(studentCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCourseExists(id))
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

        // POST: api/StudentCourses
        [ResponseType(typeof(StudentCourse))]
        public async Task<IHttpActionResult> PostStudentCourse(StudentCourse studentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentCourses.Add(studentCourse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studentCourse.StudentCourseId }, studentCourse);
        }

        // DELETE: api/StudentCourses/5
        [ResponseType(typeof(StudentCourse))]
        public async Task<IHttpActionResult> DeleteStudentCourse(int id)
        {
            StudentCourse studentCourse = await db.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            db.StudentCourses.Remove(studentCourse);
            await db.SaveChangesAsync();

            return Ok(studentCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentCourseExists(int id)
        {
            return db.StudentCourses.Count(e => e.StudentCourseId == id) > 0;
        }
    }
}