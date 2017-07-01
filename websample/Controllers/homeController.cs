using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websample.Controllers
{
    public class HomeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return View();
        }

        // GET: test1
        public ActionResult test1()
        {
            ViewBag.SelectOptions = new SelectListItem[] {
                new SelectListItem() { Value="0", Text="----" },
                new SelectListItem() { Value="2016", Text="平成28年" },
                new SelectListItem() { Value="2017", Text="平成29年" },
                new SelectListItem() { Value="2018", Text="平成30年" },
                new SelectListItem() { Value="2019", Text="平成31年" },
            };

            return View();
        }

        // GET: test1

        public class  ReqRes {
            public string res { set; get; }
            public string kana { set; get; }
            public string alpha { set; get; }
            public string type { set; get; }
            public string ym { set; get; }
            public string yy { set; get; }
            public string memo { set; get; }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult sendback(ReqRes req)
        {
            req.res = "OK";

            return Json(req);
        }
    }
}