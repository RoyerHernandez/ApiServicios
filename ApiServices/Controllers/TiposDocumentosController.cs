using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiServices.Models;

namespace ApiServices.Controllers
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
        public IHttpActionResult GetTiposDocumentos(int id)
        {
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            return Ok(tiposDocumentos);
        }

        // PUT: api/TiposDocumentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTiposDocumentos(int id, TiposDocumentos tiposDocumentos)
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
                db.SaveChanges();
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
        public IHttpActionResult PostTiposDocumentos(TiposDocumentos tiposDocumentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposDocumentos.Add(tiposDocumentos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tiposDocumentos.Id_TipoDocumento }, tiposDocumentos);
        }

        // DELETE: api/TiposDocumentos/5
        [ResponseType(typeof(TiposDocumentos))]
        public IHttpActionResult DeleteTiposDocumentos(int id)
        {
            TiposDocumentos tiposDocumentos = db.TiposDocumentos.Find(id);
            if (tiposDocumentos == null)
            {
                return NotFound();
            }

            db.TiposDocumentos.Remove(tiposDocumentos);
            db.SaveChanges();

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