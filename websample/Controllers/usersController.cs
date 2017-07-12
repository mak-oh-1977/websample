using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualBasic;
using websample.Models;

namespace websample.Controllers
{
    public class usersController : Controller
    {
        private testEntities db = new testEntities();

        // GET: users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,kana,tel,password")] user users)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
//        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,kana,tel,password")] user users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public class ApiReq
		{
			public string cmd { get; set; }
			public string res { get; set; }
			public int id { get; set; }
			public user user { get; set; }
		}

        public class userres 
        {
            public int id { get; set; }
            public int name { get; set; }
        }
		public class ApiRes
		{
			public string res { get; set; } = "OK";
			public string msg { get; set; }
			public object users { get; set; }
			public user user { get; set; }

		}
		public ActionResult Api(ApiReq req)
		{
			var res = new ApiRes();
			switch (req.cmd)
			{
				case "LIST":
                    var u = new SampleModel();
                    res.users = u.GetUsers();
                    break ;

				case "SELECT":
					{
						user users = db.users.Find(req.id);
						if (users == null)
						{
							res.res = "NG";
						}
						else
						{
							res.user = users;
						}
						break;
					}

				case "UPDATE":
					if (!ModelState.IsValid)
					{
						res.res = "NG";
					}
					else
					{
						db.Entry(req.user).State = EntityState.Modified;
						try
						{
							db.SaveChanges();
						}
						catch (Exception e)
						{
							res.res = "NG";
							res.msg = e.ToString();
						}
					}
					break;

				case "INSERT":
					if (ModelState.IsValid)
					{
						db.users.Add(req.user);
						try
						{
							db.SaveChanges();
						}
						catch (Exception e)
						{
							res.res = "NG";
							res.msg = e.ToString();
						}
					}
					break;

				default:
					res.res = "NG";
					res.msg = "Bad Request";
					break;
			}
			return Json(res);

		}
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
