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
using WebFacturacionPApi.Models;

namespace WebFacturacionPApi.Controllers
{
    public class ventasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ventas
        public IQueryable<ventas> Getventas()
        {
            return db.ventas;
        }

        // GET: api/ventas/5
        [ResponseType(typeof(ventas))]
        public async Task<IHttpActionResult> Getventas(int id)
        {
            ventas ventas = await db.ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        // PUT: api/ventas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putventas(int id, ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ventas.id)
            {
                return BadRequest();
            }

            db.Entry(ventas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ventasExists(id))
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

        // POST: api/ventas
        [ResponseType(typeof(ventas))]
        public async Task<IHttpActionResult> Postventas(ventas ventas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ventas.Add(ventas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ventas.id }, ventas);
        }

        // DELETE: api/ventas/5
        [ResponseType(typeof(ventas))]
        public async Task<IHttpActionResult> Deleteventas(int id)
        {
            ventas ventas = await db.ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            db.ventas.Remove(ventas);
            await db.SaveChangesAsync();

            return Ok(ventas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ventasExists(int id)
        {
            return db.ventas.Count(e => e.id == id) > 0;
        }
    }
}