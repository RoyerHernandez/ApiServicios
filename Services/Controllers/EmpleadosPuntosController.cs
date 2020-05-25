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
    public class EmpleadosPuntosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/EmpleadosPuntos
        public IQueryable<EmpleadosPuntos> GetEmpleadosPuntos()
        {
            return db.EmpleadosPuntos;
        }

        // GET: api/EmpleadosPuntos/5
        [ResponseType(typeof(EmpleadosPuntos))]
        public async Task<IHttpActionResult> GetEmpleadosPuntos(int id)
        {
            EmpleadosPuntos empleadosPuntos = await db.EmpleadosPuntos.FindAsync(id);
            if (empleadosPuntos == null)
            {
                return NotFound();
            }

            return Ok(empleadosPuntos);
        }

        // PUT: api/EmpleadosPuntos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpleadosPuntos(int id, EmpleadosPuntos empleadosPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadosPuntos.Id_Punto)
            {
                return BadRequest();
            }

            db.Entry(empleadosPuntos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosPuntosExists(id))
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

        // POST: api/EmpleadosPuntos
        [ResponseType(typeof(EmpleadosPuntos))]
        public async Task<IHttpActionResult> PostEmpleadosPuntos(EmpleadosPuntos empleadosPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadosPuntos.Add(empleadosPuntos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleadosPuntos.Id_Punto }, empleadosPuntos);
        }

        // DELETE: api/EmpleadosPuntos/5
        [ResponseType(typeof(EmpleadosPuntos))]
        public async Task<IHttpActionResult> DeleteEmpleadosPuntos(int id)
        {
            EmpleadosPuntos empleadosPuntos = await db.EmpleadosPuntos.FindAsync(id);
            if (empleadosPuntos == null)
            {
                return NotFound();
            }

            db.EmpleadosPuntos.Remove(empleadosPuntos);
            await db.SaveChangesAsync();

            return Ok(empleadosPuntos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosPuntosExists(int id)
        {
            return db.EmpleadosPuntos.Count(e => e.Id_Punto == id) > 0;
        }
    }
}