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
    public class TipoCalificacionsController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/TipoCalificacions
        public IQueryable<TipoCalificacion> GetTipoCalificacion()
        {
            return db.TipoCalificacion;
        }

        // GET: api/TipoCalificacions/5
        [ResponseType(typeof(TipoCalificacion))]
        public async Task<IHttpActionResult> GetTipoCalificacion(int id)
        {
            TipoCalificacion tipoCalificacion = await db.TipoCalificacion.FindAsync(id);
            if (tipoCalificacion == null)
            {
                return NotFound();
            }

            return Ok(tipoCalificacion);
        }

        // PUT: api/TipoCalificacions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoCalificacion(int id, TipoCalificacion tipoCalificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCalificacion.Id_TipoCalificacion)
            {
                return BadRequest();
            }

            db.Entry(tipoCalificacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCalificacionExists(id))
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

        // POST: api/TipoCalificacions
        [ResponseType(typeof(TipoCalificacion))]
        public async Task<IHttpActionResult> PostTipoCalificacion(TipoCalificacion tipoCalificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCalificacion.Add(tipoCalificacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoCalificacion.Id_TipoCalificacion }, tipoCalificacion);
        }

        // DELETE: api/TipoCalificacions/5
        [ResponseType(typeof(TipoCalificacion))]
        public async Task<IHttpActionResult> DeleteTipoCalificacion(int id)
        {
            TipoCalificacion tipoCalificacion = await db.TipoCalificacion.FindAsync(id);
            if (tipoCalificacion == null)
            {
                return NotFound();
            }

            db.TipoCalificacion.Remove(tipoCalificacion);
            await db.SaveChangesAsync();

            return Ok(tipoCalificacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCalificacionExists(int id)
        {
            return db.TipoCalificacion.Count(e => e.Id_TipoCalificacion == id) > 0;
        }
    }
}