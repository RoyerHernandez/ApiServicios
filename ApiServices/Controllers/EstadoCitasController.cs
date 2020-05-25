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
    public class EstadoCitasController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/EstadoCitas
        public IQueryable<EstadoCitas> GetEstadoCitas()
        {
            return db.EstadoCitas;
        }

        // GET: api/EstadoCitas/5
        [ResponseType(typeof(EstadoCitas))]
        public IHttpActionResult GetEstadoCitas(int id)
        {
            EstadoCitas estadoCitas = db.EstadoCitas.Find(id);
            if (estadoCitas == null)
            {
                return NotFound();
            }

            return Ok(estadoCitas);
        }

        // PUT: api/EstadoCitas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadoCitas(int id, EstadoCitas estadoCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoCitas.Id_EstadoCita)
            {
                return BadRequest();
            }

            db.Entry(estadoCitas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCitasExists(id))
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

        // POST: api/EstadoCitas
        [ResponseType(typeof(EstadoCitas))]
        public IHttpActionResult PostEstadoCitas(EstadoCitas estadoCitas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoCitas.Add(estadoCitas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoCitas.Id_EstadoCita }, estadoCitas);
        }

        // DELETE: api/EstadoCitas/5
        [ResponseType(typeof(EstadoCitas))]
        public IHttpActionResult DeleteEstadoCitas(int id)
        {
            EstadoCitas estadoCitas = db.EstadoCitas.Find(id);
            if (estadoCitas == null)
            {
                return NotFound();
            }

            db.EstadoCitas.Remove(estadoCitas);
            db.SaveChanges();

            return Ok(estadoCitas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoCitasExists(int id)
        {
            return db.EstadoCitas.Count(e => e.Id_EstadoCita == id) > 0;
        }
    }
}