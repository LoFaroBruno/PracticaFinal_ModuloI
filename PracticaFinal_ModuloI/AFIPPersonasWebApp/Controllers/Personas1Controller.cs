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
using AFIPPersonasWebApp.Data;
using AFIPPersonasWebApp.Models;

namespace AFIPPersonasWebApp.Controllers
{
    public class Personas1Controller : ApiController
    {
        private AFIPPersonasWebAppContext db = new AFIPPersonasWebAppContext();

        // GET: api/Personas1
        public IQueryable<Persona> GetPersonas()
        {
            return db.Personas;
        }

        // GET: api/Personas1/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.ID)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas1
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personas.Add(persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.ID }, persona);
        }

        // DELETE: api/Personas1/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            Persona persona = await db.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Personas.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Personas.Count(e => e.ID == id) > 0;
        }
    }
}