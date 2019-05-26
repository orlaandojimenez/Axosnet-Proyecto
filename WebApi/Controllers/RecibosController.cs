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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class RecibosController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Recibos
        public IQueryable<Recibo> GetRecibo()
        {
            return db.Recibo;
        }

        // GET: api/Recibos/5
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult GetRecibo(int id)
        {
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return NotFound();
            }

            return Ok(recibo);
        }

        // PUT: api/Recibos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecibo(int id, Recibo recibo)
        {
            if (id != recibo.ReciboID)
            {
                return BadRequest();
            }

            db.Entry(recibo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReciboExists(id))
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

        // POST: api/Recibos
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult PostRecibo(Recibo recibo)
        {

            db.Recibo.Add(recibo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recibo.ReciboID }, recibo);
        }

        // DELETE: api/Recibos/5
        [ResponseType(typeof(Recibo))]
        public IHttpActionResult DeleteRecibo(int id)
        {
            Recibo recibo = db.Recibo.Find(id);
            if (recibo == null)
            {
                return NotFound();
            }

            db.Recibo.Remove(recibo);
            db.SaveChanges();

            return Ok(recibo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReciboExists(int id)
        {
            return db.Recibo.Count(e => e.ReciboID == id) > 0;
        }
    }
}