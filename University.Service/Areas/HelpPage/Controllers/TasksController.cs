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
    /// <summary>
    /// Manage every things related to tasks of different employees and user  
    /// </summary>
    public class TasksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get all the tasks
        /// </summary>
        // GET: api/Tasks
        public IQueryable<Models.Task> GetTasks()
        {
            return db.Tasks;
        }
        /// <summary>
        /// Get Task by ID.
        /// </summary>
        // GET: api/Tasks/5
        [ResponseType(typeof(Models.Task))]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Update an exsisting task.
        /// </summary>
        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTask(int id, Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskId)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
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

        /// <summary>
        /// Create a new task by posting realted data
        /// </summary>
        // POST: api/Tasks
        [ResponseType(typeof(Models.Task))]
        public async Task<IHttpActionResult> PostTask(Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = task.TaskId }, task);
        }

        /// <summary>
        /// Delete a task by sending its ID
        /// </summary>
        // DELETE: api/Tasks/5
        [ResponseType(typeof(Models.Task))]
        public async Task<IHttpActionResult> DeleteTask(int id)
        {
            Models.Task task = await db.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            await db.SaveChangesAsync();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskId == id) > 0;
        }
    }
}