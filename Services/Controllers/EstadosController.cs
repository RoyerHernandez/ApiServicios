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
    public class EstadosController : ApiController
    {
        private ServicesDbEntities db = new ServicesDbEntities();

        // GET: api/Estados
        public IQueryable<Estados> GetEstados()
        {
            return db.Estados;
        }

        // GET: api/Estados/5
        [ResponseType(typeof(Estados))]
        public async Task<IHttpActionResult> GetEstados(int id)
        {
            Estados estados = await db.Estados.FindAsync(id);
            if (estados == null)
            {
                return NotFound();
            }

            return Ok(estados);
        }

        // PUT: api/Estados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEstados(int id, Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados.Id_Estado)
            {
                return BadRequest();
            }

            db.Entry(estados).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosExists(id))
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

        // POST: api/Estados
        [ResponseType(typeof(Estados))]
        public async Task<IHttpActionResult> PostEstados(Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estados.Add(estados);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = estados.Id_Estado }, estados);
        }

        // DELETE: api/Estados/5
        [ResponseType(typeof(Estados))]
        public async Task<IHttpActionResult> DeleteEstados(int id)
        {
            Estados estados = await db.Estados.FindAsync(id);
            if (estados == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estados);
            await db.SaveChangesAsync();

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosExists(int id)
        {
            return db.Estados.Count(e => e.Id_Estado == id) > 0;
        }
    }
}