using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Services.Models;

namespace Services.Controllers
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
        public async Task<IHttpActionResult> GetEmpleadosEmpresas(int id)
        {
            EmpleadosEmpresas empleadosEmpresas = await db.EmpleadosEmpresas.FindAsync(id);
            if (empleadosEmpresas == null)
            {
                return NotFound();
            }

            return Ok(empleadosEmpresas);
        }

        // PUT: api/EmpleadosEmpresas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpleadosEmpresas(int id, EmpleadosEmpresas empleadosEmpresas)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostEmpleadosEmpresas(EmpleadosEmpresas empleadosEmpresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadosEmpresas.Add(empleadosEmpresas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = empleadosEmpresas.Id_EmpleadosEmpresas }, empleadosEmpresas);
        }

        // DELETE: api/EmpleadosEmpresas/5
        [ResponseType(typeof(EmpleadosEmpresas))]
        public async Task<IHttpActionResult> DeleteEmpleadosEmpresas(int id)
        {
            EmpleadosEmpresas empleadosEmpresas = await db.EmpleadosEmpresas.FindAsync(id);
            if (empleadosEmpresas == null)
            {
                return NotFound();
            }

            db.EmpleadosEmpresas.Remove(empleadosEmpresas);
            await db.SaveChangesAsync();

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