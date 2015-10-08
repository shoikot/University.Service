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
    public class FileStoragesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FileStorages
        public IQueryable<FileStorage> GetFileStorages()
        {
            return db.FileStorages;
        }

        // GET: api/FileStorages/5
        [ResponseType(typeof(FileStorage))]
        public async Task<IHttpActionResult> GetFileStorage(int id)
        {
            FileStorage fileStorage = await db.FileStorages.FindAsync(id);
            if (fileStorage == null)
            {
                return NotFound();
            }

            return Ok(fileStorage);
        }

        // PUT: api/FileStorages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFileStorage(int id, FileStorage fileStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fileStorage.FileStorageId)
            {
                return BadRequest();
            }

            db.Entry(fileStorage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FileStorageExists(id))
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

        // POST: api/FileStorages
        [ResponseType(typeof(FileStorage))]
        public async Task<IHttpActionResult> PostFileStorage(FileStorage fileStorage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FileStorages.Add(fileStorage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fileStorage.FileStorageId }, fileStorage);
        }

        // DELETE: api/FileStorages/5
        [ResponseType(typeof(FileStorage))]
        public async Task<IHttpActionResult> DeleteFileStorage(int id)
        {
            FileStorage fileStorage = await db.FileStorages.FindAsync(id);
            if (fileStorage == null)
            {
                return NotFound();
            }

            db.FileStorages.Remove(fileStorage);
            await db.SaveChangesAsync();

            return Ok(fileStorage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FileStorageExists(int id)
        {
            return db.FileStorages.Count(e => e.FileStorageId == id) > 0;
        }
    }
}