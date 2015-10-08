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
    public class DepartmentCoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DepartmentCourses
        public IQueryable<DepartmentCourse> GetDepartmentCourses()
        {
            return db.DepartmentCourses;
        }

        // GET: api/DepartmentCourses/5
        [ResponseType(typeof(DepartmentCourse))]
        public async Task<IHttpActionResult> GetDepartmentCourse(int id)
        {
            DepartmentCourse departmentCourse = await db.DepartmentCourses.FindAsync(id);
            if (departmentCourse == null)
            {
                return NotFound();
            }

            return Ok(departmentCourse);
        }

        // PUT: api/DepartmentCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartmentCourse(int id, DepartmentCourse departmentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departmentCourse.DepartmentCourseId)
            {
                return BadRequest();
            }

            db.Entry(departmentCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentCourseExists(id))
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

        // POST: api/DepartmentCourses
        [ResponseType(typeof(DepartmentCourse))]
        public async Task<IHttpActionResult> PostDepartmentCourse(DepartmentCourse departmentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DepartmentCourses.Add(departmentCourse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = departmentCourse.DepartmentCourseId }, departmentCourse);
        }

        // DELETE: api/DepartmentCourses/5
        [ResponseType(typeof(DepartmentCourse))]
        public async Task<IHttpActionResult> DeleteDepartmentCourse(int id)
        {
            DepartmentCourse departmentCourse = await db.DepartmentCourses.FindAsync(id);
            if (departmentCourse == null)
            {
                return NotFound();
            }

            db.DepartmentCourses.Remove(departmentCourse);
            await db.SaveChangesAsync();

            return Ok(departmentCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentCourseExists(int id)
        {
            return db.DepartmentCourses.Count(e => e.DepartmentCourseId == id) > 0;
        }
    }
}