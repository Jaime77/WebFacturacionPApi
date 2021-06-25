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
    public class inventariosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/inventarios
        public IQueryable<inventario> Getinventario()
        {
            return db.inventario;
        }

        // GET: api/inventarios/5
        [ResponseType(typeof(inventario))]
        public async Task<IHttpActionResult> Getinventario(int id)
        {
            inventario inventario = await db.inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }

        // PUT: api/inventarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putinventario(int id, inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventario.id)
            {
                return BadRequest();
            }

            db.Entry(inventario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inventarioExists(id))
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

        // POST: api/inventarios
        [ResponseType(typeof(inventario))]
        public async Task<IHttpActionResult> Postinventario(inventario inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.inventario.Add(inventario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inventario.id }, inventario);
        }

        // DELETE: api/inventarios/5
        [ResponseType(typeof(inventario))]
        public async Task<IHttpActionResult> Deleteinventario(int id)
        {
            inventario inventario = await db.inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            db.inventario.Remove(inventario);
            await db.SaveChangesAsync();

            return Ok(inventario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inventarioExists(int id)
        {
            return db.inventario.Count(e => e.id == id) > 0;
        }
    }
}