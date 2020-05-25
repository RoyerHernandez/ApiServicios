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
    public class DisponibilidadsController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Disponibilidads
        public IQueryable<Disponibilidad> GetDisponibilidad()
        {
            return db.Disponibilidad;
        }

        // GET: api/Disponibilidads/5
        [ResponseType(typeof(Disponibilidad))]
        public async Task<IHttpActionResult> GetDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = await db.Disponibilidad.FindAsync(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return Ok(disponibilidad);
        }

        // PUT: api/Disponibilidads/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDisponibilidad(int id, Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disponibilidad.Id_Disponibilidad)
            {
                return BadRequest();
            }

            db.Entry(disponibilidad).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadExists(id))
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

        // POST: api/Disponibilidads
        [ResponseType(typeof(Disponibilidad))]
        public async Task<IHttpActionResult> PostDisponibilidad(Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disponibilidad.Add(disponibilidad);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = disponibilidad.Id_Disponibilidad }, disponibilidad);
        }

        // DELETE: api/Disponibilidads/5
        [ResponseType(typeof(Disponibilidad))]
        public async Task<IHttpActionResult> DeleteDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = await db.Disponibilidad.FindAsync(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            db.Disponibilidad.Remove(disponibilidad);
            await db.SaveChangesAsync();

            return Ok(disponibilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisponibilidadExists(int id)
        {
            return db.Disponibilidad.Count(e => e.Id_Disponibilidad == id) > 0;
        }
    }
}