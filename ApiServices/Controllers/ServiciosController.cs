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
    public class ServiciosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Servicios
        public IQueryable<Servicios> GetServicios()
        {
            return db.Servicios;
        }

        // GET: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult GetServicios(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return NotFound();
            }

            return Ok(servicios);
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServicios(int id, Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios.Id_Servicio)
            {
                return BadRequest();
            }

            db.Entry(servicios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
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

        // POST: api/Servicios
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult PostServicios(Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicios.Id_Servicio }, servicios);
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult DeleteServicios(int id)
        {
            Servicios servicios = db.Servicios.Find(id);
            if (servicios == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicios);
            db.SaveChanges();

            return Ok(servicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosExists(int id)
        {
            return db.Servicios.Count(e => e.Id_Servicio == id) > 0;
        }
    }
}