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
    public class TiposServiciosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/TiposServicios
        public IQueryable<TiposServicios> GetTiposServicios()
        {
            return db.TiposServicios;
        }

        // GET: api/TiposServicios/5
        [ResponseType(typeof(TiposServicios))]
        public IHttpActionResult GetTiposServicios(int id)
        {
            TiposServicios tiposServicios = db.TiposServicios.Find(id);
            if (tiposServicios == null)
            {
                return NotFound();
            }

            return Ok(tiposServicios);
        }

        // PUT: api/TiposServicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTiposServicios(int id, TiposServicios tiposServicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tiposServicios.Id_TipoServicio)
            {
                return BadRequest();
            }

            db.Entry(tiposServicios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposServiciosExists(id))
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

        // POST: api/TiposServicios
        [ResponseType(typeof(TiposServicios))]
        public IHttpActionResult PostTiposServicios(TiposServicios tiposServicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposServicios.Add(tiposServicios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tiposServicios.Id_TipoServicio }, tiposServicios);
        }

        // DELETE: api/TiposServicios/5
        [ResponseType(typeof(TiposServicios))]
        public IHttpActionResult DeleteTiposServicios(int id)
        {
            TiposServicios tiposServicios = db.TiposServicios.Find(id);
            if (tiposServicios == null)
            {
                return NotFound();
            }

            db.TiposServicios.Remove(tiposServicios);
            db.SaveChanges();

            return Ok(tiposServicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TiposServiciosExists(int id)
        {
            return db.TiposServicios.Count(e => e.Id_TipoServicio == id) > 0;
        }
    }
}