using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using websample.Models;
using System.Drawing.Printing;
using TuesPechkin;

namespace websample.Controllers
{
    public class pdfController : Controller
    {
        private testEntities db = new testEntities();

        // GET: pdf
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: pdf/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
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
        public ActionResult pdf(int? id)
        {
            var helper = new UrlHelper(ControllerContext.RequestContext);
            var indexUrl = helper.Action("Details", "pdf", new { id = id }, Request.Url.Scheme);

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


        // POST: pdf/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,kana,tel,password")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
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
