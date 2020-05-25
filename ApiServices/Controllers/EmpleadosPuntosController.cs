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
    public class EmpleadosPuntosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/EmpleadosPuntos
        public IQueryable<EmpleadosPuntos> GetEmpleadosPuntos()
        {
            return db.EmpleadosPuntos;
        }

        // GET: api/EmpleadosPuntos/5
        [ResponseType(typeof(EmpleadosPuntos))]
        public IHttpActionResult GetEmpleadosPuntos(int id)
        {
            EmpleadosPuntos empleadosPuntos = db.EmpleadosPuntos.Find(id);
            if (empleadosPuntos == null)
            {
                return NotFound();
            }

            return Ok(empleadosPuntos);
        }

        // PUT: api/EmpleadosPuntos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleadosPuntos(int id, EmpleadosPuntos empleadosPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadosPuntos.Id_Punto)
            {
                return BadRequest();
            }

            db.Entry(empleadosPuntos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosPuntosExists(id))
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

        // POST: api/EmpleadosPuntos
        [ResponseType(typeof(EmpleadosPuntos))]
        public IHttpActionResult PostEmpleadosPuntos(EmpleadosPuntos empleadosPuntos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadosPuntos.Add(empleadosPuntos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleadosPuntos.Id_Punto }, empleadosPuntos);
        }

        // DELETE: api/EmpleadosPuntos/5
        [ResponseType(typeof(EmpleadosPuntos))]
        public IHttpActionResult DeleteEmpleadosPuntos(int id)
        {
            EmpleadosPuntos empleadosPuntos = db.EmpleadosPuntos.Find(id);
            if (empleadosPuntos == null)
            {
                return NotFound();
            }

            db.EmpleadosPuntos.Remove(empleadosPuntos);
            db.SaveChanges();

            return Ok(empleadosPuntos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosPuntosExists(int id)
        {
            return db.EmpleadosPuntos.Count(e => e.Id_Punto == id) > 0;
        }
    }
}