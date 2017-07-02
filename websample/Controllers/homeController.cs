using System.Drawing.Printing;
using System.Web.Mvc;
using TuesPechkin;

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

        // アプリケーションで単一のインスタンスとする
        private static IConverter Converter =
            new ThreadSafeConverter(
                new RemotingToolset<PdfToolset>(
                    new WinAnyCPUEmbeddedDeployment(
                        new TempFolderDeployment())));
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult pdf(ReqRes req)
        {
            var helper = new UrlHelper(ControllerContext.RequestContext);
            var indexUrl = helper.Action("Index", "Home", null, Request.Url.Scheme);

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ProduceOutline = true,
                    DocumentTitle = "PDF Sample",
                    PaperSize = PaperKind.A4,
                    Margins =
                    {
                        All = 1.375,
                        Unit = Unit.Centimeters
                    }
                },
                Objects =
                {
                    new ObjectSettings() {
                        PageUrl = indexUrl,
                    },
                }
            };

            var pdfData = Converter.Convert(document);

            return File(pdfData, "application/pdf", "PdfSample.pdf");
        }

    }

}
