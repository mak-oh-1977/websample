using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    
        public class ApiRes{
            public string res { get; set; }
            public string msg { get; set; }
        }

        public JsonResult Login()
        {
            var ret = new ApiRes
            {
                res = "OK"
            };
            
            return Json(ret);
        }
    }
}