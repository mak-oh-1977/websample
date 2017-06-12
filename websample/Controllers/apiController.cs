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
using websample.Models;

namespace websample.Controllers
{
    public class apiController : ApiController
    {
        private testEntities db = new testEntities();

        // GET: api/api
        public IQueryable<users> Getusers()
        {
            return db.users;
        }

        // GET: api/api/5
        [ResponseType(typeof(users))]
        public IHttpActionResult Getusers(int id)
        {
            users users = db.users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/api/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putusers(int id, users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.id)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usersExists(id))
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

        // POST: api/api
        [ResponseType(typeof(users))]
        public IHttpActionResult Postusers(users users)
        {
			if (users.cmd == "SELECT")
			{
				users usersRes = db.users.Find(users.id);
				if (usersRes == null)
				{
					return NotFound();
				}
				usersRes.res = "OK";

				return Ok(usersRes);
			}
			if (users.cmd == "UPDATE")
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				db.Entry(users).State = EntityState.Modified;

				try
				{
					db.SaveChanges();

					users.res = "OK";

					return Ok(users);
				}
				catch (DbUpdateConcurrencyException)
				{
					throw;
				}

				return StatusCode(HttpStatusCode.NoContent);

			}
			return BadRequest();
			/*


                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        db.users.Add(users);

                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateException)
                        {
                            if (usersExists(users.id))
                            {
                                return Conflict();
                            }
                            else
                            {
                                throw;
                            }
                        }

                        return CreatedAtRoute("DefaultApi", new { id = users.id }, users);
            */
		}

		// DELETE: api/api/5
		[ResponseType(typeof(users))]
        public IHttpActionResult Deleteusers(int id)
        {
            users users = db.users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usersExists(int id)
        {
            return db.users.Count(e => e.id == id) > 0;
        }
    }
}