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
using AJSWebapi.Models;

namespace AJSWebapi.Controllers
{
    public class TVShowsController : ApiController
    {
        private AJSWebapiContext db = new AJSWebapiContext();

        // GET: api/TVShows
        public IQueryable<TVShow> GetTVShows()
        {
            return db.TVShows;
        }

        // GET: api/TVShows/5
        [ResponseType(typeof(TVShow))]
        public async Task<IHttpActionResult> GetTVShow(int id)
        {
            TVShow tVShow = await db.TVShows.FindAsync(id);
            if (tVShow == null)
            {
                return NotFound();
            }

            return Ok(tVShow);
        }

        // PUT: api/TVShows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTVShow(int id, TVShow tVShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tVShow.Id)
            {
                return BadRequest();
            }

            db.Entry(tVShow).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TVShowExists(id))
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

        // POST: api/TVShows
        [ResponseType(typeof(TVShow))]
        public async Task<IHttpActionResult> PostTVShow(TVShow tVShow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TVShows.Add(tVShow);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tVShow.Id }, tVShow);
        }

        // DELETE: api/TVShows/5
        [ResponseType(typeof(TVShow))]
        public async Task<IHttpActionResult> DeleteTVShow(int id)
        {
            TVShow tVShow = await db.TVShows.FindAsync(id);
            if (tVShow == null)
            {
                return NotFound();
            }

            db.TVShows.Remove(tVShow);
            await db.SaveChangesAsync();

            return Ok(tVShow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TVShowExists(int id)
        {
            return db.TVShows.Count(e => e.Id == id) > 0;
        }
    }
}