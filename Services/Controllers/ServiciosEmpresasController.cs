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
        public async Task<IHttpActionResult> GetServiciosEmpresa(int id)
        {
            ServiciosEmpresa serviciosEmpresa = await db.ServiciosEmpresa.FindAsync(id);
            if (serviciosEmpresa == null)
            {
                return NotFound();
            }

            return Ok(serviciosEmpresa);
        }

        // PUT: api/ServiciosEmpresas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutServiciosEmpresa(int id, ServiciosEmpresa serviciosEmpresa)
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
                await db.SaveChangesAsync();
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
        public async Task<IHttpActionResult> PostServiciosEmpresa(ServiciosEmpresa serviciosEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiciosEmpresa.Add(serviciosEmpresa);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = serviciosEmpresa.Id_ServicioEmpresa }, serviciosEmpresa);
        }

        // DELETE: api/ServiciosEmpresas/5
        [ResponseType(typeof(ServiciosEmpresa))]
        public async Task<IHttpActionResult> DeleteServiciosEmpresa(int id)
        {
            ServiciosEmpresa serviciosEmpresa = await db.ServiciosEmpresa.FindAsync(id);
            if (serviciosEmpresa == null)
            {
                return NotFound();
            }

            db.ServiciosEmpresa.Remove(serviciosEmpresa);
            await db.SaveChangesAsync();

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