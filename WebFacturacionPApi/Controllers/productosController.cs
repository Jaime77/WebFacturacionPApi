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
using WebFacturacionPApi.Models;

namespace WebFacturacionPApi.Controllers
{
    public class productosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/productos
        public IQueryable<productos> Getproductos()
        {
            return db.productos;
        }

        // GET: api/productos/5
        [ResponseType(typeof(productos))]
        public IHttpActionResult Getproductos(int id)
        {
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        // PUT: api/productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproductos(int id, productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productos.id)
            {
                return BadRequest();
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productosExists(id))
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

        // POST: api/productos
        [ResponseType(typeof(productos))]
        public IHttpActionResult Postproductos(productos productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.productos.Add(productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productos.id }, productos);
        }

        // DELETE: api/productos/5
        [ResponseType(typeof(productos))]
        public IHttpActionResult Deleteproductos(int id)
        {
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }

            db.productos.Remove(productos);
            db.SaveChanges();

            return Ok(productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productosExists(int id)
        {
            return db.productos.Count(e => e.id == id) > 0;
        }
    }
}