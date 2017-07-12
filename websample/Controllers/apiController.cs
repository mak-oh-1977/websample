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


		public class Response
		{
			public string cmd { get; set; }
			public string res { get; set; }
			public int id { get; set; }
			public DbSet<user> users { get; set; }
			public user user { get; set; }
		}

        // POST: api/api
        [ResponseType(typeof(Response))]
        public IHttpActionResult Postusers(Response req)
        {
			if (req.cmd == "LIST")
			{
				Response res = new Response();
				res.res = "OK";
				res.users = db.users;	
				return Ok(res);
			}
			if (req.cmd == "SELECT")
			{
				user users = db.users.Find(req.id);
				if (users == null)
				{
					return NotFound();
				}
				Response res = new Response();
				res.res = "OK";
				res.user = users;

				return Ok(res);
			}
			if (req.cmd == "UPDATE")
			{
				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}
				user users = db.users.Find(req.user.Id);
				if (users == null)
				{
					 db.users.Add(req.user);
				}
				else
				{
					db.Entry(req.user).State = EntityState.Modified;
				}
				try
				{
					db.SaveChanges();

					Response res = new Response();
					res.res = "OK";

					return Ok(res);
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
		[ResponseType(typeof(user))]
        public IHttpActionResult Deleteusers(int id)
        {
            user users = db.users.Find(id);
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
            return db.users.Count(e => e.Id == id) > 0;
        }
    }
}