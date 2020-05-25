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
    public class PuntosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Puntos
        public IQueryable<Puntos> GetPuntos()
        {
            return db.Puntos;
        }

        // GET: api/Puntos/5
        [ResponseType(typeof(Puntos))]
        public async Task<IHttpActionResult> GetPuntos(int id)
        {
            Puntos puntos = await db.Puntos.FindAsync(id);
            if (puntos == null)
            {
                return NotFound();
            }

            return Ok(puntos);
        }

        // PUT: api/Puntos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPuntos(int id, Puntos puntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puntos.Id_Punto)
            {
                return BadRequest();
            }

            db.Entry(puntos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntosExists(id))
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

        // POST: api/Puntos
        [ResponseType(typeof(Puntos))]
        public async Task<IHttpActionResult> PostPuntos(Puntos puntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Puntos.Add(puntos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = puntos.Id_Punto }, puntos);
        }

        // DELETE: api/Puntos/5
        [ResponseType(typeof(Puntos))]
        public async Task<IHttpActionResult> DeletePuntos(int id)
        {
            Puntos puntos = await db.Puntos.FindAsync(id);
            if (puntos == null)
            {
                return NotFound();
            }

            db.Puntos.Remove(puntos);
            await db.SaveChangesAsync();

            return Ok(puntos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuntosExists(int id)
        {
            return db.Puntos.Count(e => e.Id_Punto == id) > 0;
        }
    }
}