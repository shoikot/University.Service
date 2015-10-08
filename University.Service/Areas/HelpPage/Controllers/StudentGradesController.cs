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
    public class StudentGradesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StudentGrades
        public IQueryable<StudentGrade> GetStudentGrades()
        {
            return db.StudentGrades;
        }

        // GET: api/StudentGrades/5
        [ResponseType(typeof(StudentGrade))]
        public async Task<IHttpActionResult> GetStudentGrade(int id)
        {
            StudentGrade studentGrade = await db.StudentGrades.FindAsync(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            return Ok(studentGrade);
        }

        // PUT: api/StudentGrades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentGrade(int id, StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentGrade.StudentGradeId)
            {
                return BadRequest();
            }

            db.Entry(studentGrade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradeExists(id))
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

        // POST: api/StudentGrades
        [ResponseType(typeof(StudentGrade))]
        public async Task<IHttpActionResult> PostStudentGrade(StudentGrade studentGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentGrades.Add(studentGrade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = studentGrade.StudentGradeId }, studentGrade);
        }

        // DELETE: api/StudentGrades/5
        [ResponseType(typeof(StudentGrade))]
        public async Task<IHttpActionResult> DeleteStudentGrade(int id)
        {
            StudentGrade studentGrade = await db.StudentGrades.FindAsync(id);
            if (studentGrade == null)
            {
                return NotFound();
            }

            db.StudentGrades.Remove(studentGrade);
            await db.SaveChangesAsync();

            return Ok(studentGrade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentGradeExists(int id)
        {
            return db.StudentGrades.Count(e => e.StudentGradeId == id) > 0;
        }
    }
}