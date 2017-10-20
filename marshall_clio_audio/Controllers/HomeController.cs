using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marshall_clio_audio.Models;

namespace marshall_clio_audio.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var ctx = new ApplicationDbContext();

                int FileLength = file.ContentLength;
                byte[] FileContents = new byte[FileLength];

                file.InputStream.Read(FileContents, 0, FileLength);

                AudioFile af = new AudioFile
                {
                    Name = "",
                    WAVData = FileContents
                };
                ctx.AudioFiles.Add(af);

                ctx.SaveChanges();

                ViewBag.Message = "File upload was successful.";
            } else
            {
                ViewBag.Message = "Could not upload the file.";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var ctx = new ApplicationDbContext();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This is a site assisting Clio.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us";

            return View();
        }
    }
}