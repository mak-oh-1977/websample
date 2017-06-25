using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }

        // GET: test1
        public ActionResult test1()
        {
            return View();
        }
    }
}