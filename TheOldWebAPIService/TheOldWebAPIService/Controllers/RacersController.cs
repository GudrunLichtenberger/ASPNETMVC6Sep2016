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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using TheOldWebAPIService.Models;

namespace TheOldWebAPIService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using TheOldWebAPIService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Racer>("Racers");
    builder.EntitySet<RaceResult>("RaceResults"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RacersController : ODataController
    {
        private Formula1Model db = new Formula1Model();

        // GET: odata/Racers
        [EnableQuery]
        public IQueryable<Racer> GetRacers()
        {
            return db.Racers;
        }

        // GET: odata/Racers(5)
        [EnableQuery]
        public SingleResult<Racer> GetRacer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Racers.Where(racer => racer.Id == key));
        }

        // PUT: odata/Racers(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Racer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Racer racer = await db.Racers.FindAsync(key);
            if (racer == null)
            {
                return NotFound();
            }

            patch.Put(racer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // POST: odata/Racers
        public async Task<IHttpActionResult> Post(Racer racer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Racers.Add(racer);
            await db.SaveChangesAsync();

            return Created(racer);
        }

        // PATCH: odata/Racers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Racer> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Racer racer = await db.Racers.FindAsync(key);
            if (racer == null)
            {
                return NotFound();
            }

            patch.Patch(racer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // DELETE: odata/Racers(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Racer racer = await db.Racers.FindAsync(key);
            if (racer == null)
            {
                return NotFound();
            }

            db.Racers.Remove(racer);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Racers(5)/RaceResults
        [EnableQuery]
        public IQueryable<RaceResult> GetRaceResults([FromODataUri] int key)
        {
            return db.Racers.Where(m => m.Id == key).SelectMany(m => m.RaceResults);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RacerExists(int key)
        {
            return db.Racers.Count(e => e.Id == key) > 0;
        }
    }
}
