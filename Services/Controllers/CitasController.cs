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
using Services.Models;

namespace Services.Controllers
{
    public class CitasController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Citas
        public IQueryable<Citas> GetCitas()
        {
            return db.Citas;
        }

        // GET: api/Citas/5
        [ResponseType(typeof(Citas))]
        public async Task<IHttpActionResult> GetCitas(int id)
        {
            Citas citas = await db.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            return Ok(citas);
        }

        // PUT: api/Citas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCitas(int id, Citas citas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citas.Id_Cita)
            {
                return BadRequest();
            }

            db.Entry(citas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitasExists(id))
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

        // POST: api/Citas
        [ResponseType(typeof(Citas))]
        public async Task<IHttpActionResult> PostCitas(Citas citas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Citas.Add(citas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = citas.Id_Cita }, citas);
        }

        // DELETE: api/Citas/5
        [ResponseType(typeof(Citas))]
        public async Task<IHttpActionResult> DeleteCitas(int id)
        {
            Citas citas = await db.Citas.FindAsync(id);
            if (citas == null)
            {
                return NotFound();
            }

            db.Citas.Remove(citas);
            await db.SaveChangesAsync();

            return Ok(citas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitasExists(int id)
        {
            return db.Citas.Count(e => e.Id_Cita == id) > 0;
        }
    }
}