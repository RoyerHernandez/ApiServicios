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
    public class ServiciosEmpresasPuntosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/ServiciosEmpresasPuntos
        public IQueryable<ServiciosEmpresasPuntos> GetServiciosEmpresasPuntos()
        {
            return db.ServiciosEmpresasPuntos;
        }

        // GET: api/ServiciosEmpresasPuntos/5
        [ResponseType(typeof(ServiciosEmpresasPuntos))]
        public IHttpActionResult GetServiciosEmpresasPuntos(int id)
        {
            ServiciosEmpresasPuntos serviciosEmpresasPuntos = db.ServiciosEmpresasPuntos.Find(id);
            if (serviciosEmpresasPuntos == null)
            {
                return NotFound();
            }

            return Ok(serviciosEmpresasPuntos);
        }

        // PUT: api/ServiciosEmpresasPuntos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiciosEmpresasPuntos(int id, ServiciosEmpresasPuntos serviciosEmpresasPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviciosEmpresasPuntos.Id_ServicioEmpresaPunto)
            {
                return BadRequest();
            }

            db.Entry(serviciosEmpresasPuntos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosEmpresasPuntosExists(id))
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

        // POST: api/ServiciosEmpresasPuntos
        [ResponseType(typeof(ServiciosEmpresasPuntos))]
        public IHttpActionResult PostServiciosEmpresasPuntos(ServiciosEmpresasPuntos serviciosEmpresasPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosEmpresasPuntos.Add(serviciosEmpresasPuntos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviciosEmpresasPuntos.Id_ServicioEmpresaPunto }, serviciosEmpresasPuntos);
        }

        // DELETE: api/ServiciosEmpresasPuntos/5
        [ResponseType(typeof(ServiciosEmpresasPuntos))]
        public IHttpActionResult DeleteServiciosEmpresasPuntos(int id)
        {
            ServiciosEmpresasPuntos serviciosEmpresasPuntos = db.ServiciosEmpresasPuntos.Find(id);
            if (serviciosEmpresasPuntos == null)
            {
                return NotFound();
            }

            db.ServiciosEmpresasPuntos.Remove(serviciosEmpresasPuntos);
            db.SaveChanges();

            return Ok(serviciosEmpresasPuntos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosEmpresasPuntosExists(int id)
        {
            return db.ServiciosEmpresasPuntos.Count(e => e.Id_ServicioEmpresaPunto == id) > 0;
        }
    }
}