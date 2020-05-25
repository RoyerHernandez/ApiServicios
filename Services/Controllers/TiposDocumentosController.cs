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
    public class TiposDocumentosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/TiposDocumentos
        public IQueryable<TiposDocumentos> GetTiposDocumentos()
        {
            return db.TiposDocumentos;
        }

        // GET: api/TiposDocumentos/5
        [ResponseType(typeof(TiposDocumentos))]
        public async Task<IHttpActionResult> GetTiposDocumentos(int id)
        {
            TiposDocumentos tiposDocumentos = await db.TiposDocumentos.FindAsync(id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            return Ok(tiposDocumentos);
        }

        // PUT: api/TiposDocumentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTiposDocumentos(int id, TiposDocumentos tiposDocumentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposDocumentos.Id_TipoDocumento)
            {
                return BadRequest();
            }

            db.Entry(tiposDocumentos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentosExists(id))
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

        // POST: api/TiposDocumentos
        [ResponseType(typeof(TiposDocumentos))]
        public async Task<IHttpActionResult> PostTiposDocumentos(TiposDocumentos tiposDocumentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposDocumentos.Add(tiposDocumentos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tiposDocumentos.Id_TipoDocumento }, tiposDocumentos);
        }

        // DELETE: api/TiposDocumentos/5
        [ResponseType(typeof(TiposDocumentos))]
        public async Task<IHttpActionResult> DeleteTiposDocumentos(int id)
        {
            TiposDocumentos tiposDocumentos = await db.TiposDocumentos.FindAsync(id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            db.TiposDocumentos.Remove(tiposDocumentos);
            await db.SaveChangesAsync();

            return Ok(tiposDocumentos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiposDocumentosExists(int id)
        {
            return db.TiposDocumentos.Count(e => e.Id_TipoDocumento == id) > 0;
        }
    }
}