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
        public IHttpActionResult GetTipoCalificacion(int id)
        {
            TipoCalificacion tipoCalificacion = db.TipoCalificacion.Find(id);
            if (tipoCalificacion == null)
            {
                return NotFound();
            }

            return Ok(tipoCalificacion);
        }

        // PUT: api/TipoCalificacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCalificacion(int id, TipoCalificacion tipoCalificacion)
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
                db.SaveChanges();
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
        public IHttpActionResult PostTipoCalificacion(TipoCalificacion tipoCalificacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCalificacion.Add(tipoCalificacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCalificacion.Id_TipoCalificacion }, tipoCalificacion);
        }

        // DELETE: api/TipoCalificacions/5
        [ResponseType(typeof(TipoCalificacion))]
        public IHttpActionResult DeleteTipoCalificacion(int id)
        {
            TipoCalificacion tipoCalificacion = db.TipoCalificacion.Find(id);
            if (tipoCalificacion == null)
            {
                return NotFound();
            }

            db.TipoCalificacion.Remove(tipoCalificacion);
            db.SaveChanges();

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