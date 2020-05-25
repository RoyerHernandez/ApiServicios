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
    public class EmpleadosEmpresasController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/EmpleadosEmpresas
        public IQueryable<EmpleadosEmpresas> GetEmpleadosEmpresas()
        {
            return db.EmpleadosEmpresas;
        }

        // GET: api/EmpleadosEmpresas/5
        [ResponseType(typeof(EmpleadosEmpresas))]
        public IHttpActionResult GetEmpleadosEmpresas(int id)
        {
            EmpleadosEmpresas empleadosEmpresas = db.EmpleadosEmpresas.Find(id);
            if (empleadosEmpresas == null)
            {
                return NotFound();
            }

            return Ok(empleadosEmpresas);
        }

        // PUT: api/EmpleadosEmpresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleadosEmpresas(int id, EmpleadosEmpresas empleadosEmpresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadosEmpresas.Id_EmpleadosEmpresas)
            {
                return BadRequest();
            }

            db.Entry(empleadosEmpresas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosEmpresasExists(id))
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

        // POST: api/EmpleadosEmpresas
        [ResponseType(typeof(EmpleadosEmpresas))]
        public IHttpActionResult PostEmpleadosEmpresas(EmpleadosEmpresas empleadosEmpresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadosEmpresas.Add(empleadosEmpresas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleadosEmpresas.Id_EmpleadosEmpresas }, empleadosEmpresas);
        }

        // DELETE: api/EmpleadosEmpresas/5
        [ResponseType(typeof(EmpleadosEmpresas))]
        public IHttpActionResult DeleteEmpleadosEmpresas(int id)
        {
            EmpleadosEmpresas empleadosEmpresas = db.EmpleadosEmpresas.Find(id);
            if (empleadosEmpresas == null)
            {
                return NotFound();
            }

            db.EmpleadosEmpresas.Remove(empleadosEmpresas);
            db.SaveChanges();

            return Ok(empleadosEmpresas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosEmpresasExists(int id)
        {
            return db.EmpleadosEmpresas.Count(e => e.Id_EmpleadosEmpresas == id) > 0;
        }
    }
}