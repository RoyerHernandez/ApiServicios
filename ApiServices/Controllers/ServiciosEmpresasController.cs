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
    public class ServiciosEmpresasController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/ServiciosEmpresas
        public IQueryable<ServiciosEmpresa> GetServiciosEmpresa()
        {
            return db.ServiciosEmpresa;
        }

        // GET: api/ServiciosEmpresas/5
        [ResponseType(typeof(ServiciosEmpresa))]
        public IHttpActionResult GetServiciosEmpresa(int id)
        {
            ServiciosEmpresa serviciosEmpresa = db.ServiciosEmpresa.Find(id);
            if (serviciosEmpresa == null)
            {
                return NotFound();
            }

            return Ok(serviciosEmpresa);
        }

        // PUT: api/ServiciosEmpresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiciosEmpresa(int id, ServiciosEmpresa serviciosEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviciosEmpresa.Id_ServicioEmpresa)
            {
                return BadRequest();
            }

            db.Entry(serviciosEmpresa).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosEmpresaExists(id))
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

        // POST: api/ServiciosEmpresas
        [ResponseType(typeof(ServiciosEmpresa))]
        public IHttpActionResult PostServiciosEmpresa(ServiciosEmpresa serviciosEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosEmpresa.Add(serviciosEmpresa);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviciosEmpresa.Id_ServicioEmpresa }, serviciosEmpresa);
        }

        // DELETE: api/ServiciosEmpresas/5
        [ResponseType(typeof(ServiciosEmpresa))]
        public IHttpActionResult DeleteServiciosEmpresa(int id)
        {
            ServiciosEmpresa serviciosEmpresa = db.ServiciosEmpresa.Find(id);
            if (serviciosEmpresa == null)
            {
                return NotFound();
            }

            db.ServiciosEmpresa.Remove(serviciosEmpresa);
            db.SaveChanges();

            return Ok(serviciosEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosEmpresaExists(int id)
        {
            return db.ServiciosEmpresa.Count(e => e.Id_ServicioEmpresa == id) > 0;
        }
    }
}