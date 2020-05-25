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
    public class DisponibilidadsController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Disponibilidads
        public IQueryable<Disponibilidad> GetDisponibilidad()
        {
            return db.Disponibilidad;
        }

        // GET: api/Disponibilidads/5
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult GetDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidad.Find(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return Ok(disponibilidad);
        }

        // PUT: api/Disponibilidads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisponibilidad(int id, Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disponibilidad.Id_Disponibilidad)
            {
                return BadRequest();
            }

            db.Entry(disponibilidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadExists(id))
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

        // POST: api/Disponibilidads
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult PostDisponibilidad(Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disponibilidad.Add(disponibilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disponibilidad.Id_Disponibilidad }, disponibilidad);
        }

        // DELETE: api/Disponibilidads/5
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult DeleteDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidad.Find(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            db.Disponibilidad.Remove(disponibilidad);
            db.SaveChanges();

            return Ok(disponibilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisponibilidadExists(int id)
        {
            return db.Disponibilidad.Count(e => e.Id_Disponibilidad == id) > 0;
        }
    }
}