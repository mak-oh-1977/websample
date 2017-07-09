using System.Drawing.Printing;
using System.Web.Mvc;
using TuesPechkin;

namespace websample.Controllers
{
    using StringEx;

    public class MenuController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            string s = "";
            ViewBag.Title = s.JapaneseNumber();

            return View();
        }

    }

}
