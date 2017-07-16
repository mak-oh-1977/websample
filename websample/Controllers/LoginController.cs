using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using websample.Models;

namespace websample.Controllers
{
    [AllowAnonymous]
    public class LoginController : _Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    
        public class LoginReq {
            public string loginid { get; set; }
            public string password { get; set; }
        }

        public class ApiRes{
            public string res { get; set; }
            public string msg { get; set; }
            public object data { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginReq req)
        {
            SValue.UID = req.loginid;
            var m = new SampleModel();
            var ret = m.CheckLogin(req.loginid, req.password);

            if (ret != null)
            {
                FormsAuthentication.SetAuthCookie(req.loginid, false);
                return RedirectToAction("Index", "Menu");
            }
            else
            {
                ViewBag.Msg = "認証に失敗しました";
            }

            return View();
        }
    }
}