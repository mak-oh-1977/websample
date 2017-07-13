using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class LoginController : _Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    
        public class LoginReq {
            public string id { get; set; }
            public string password { get; set; }
        }

        public class ApiRes{
            public string res { get; set; }
            public string msg { get; set; }
        }

        public JsonResult Login(LoginReq req)
        {
            sv.UID = req.id;
            var ret = new ApiRes
            {
                res = "OK"
            };
            
            return Json(ret);
        }
    }
}