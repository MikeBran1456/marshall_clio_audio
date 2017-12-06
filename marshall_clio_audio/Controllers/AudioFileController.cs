using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marshall_clio_audio.Models;
using Microsoft.AspNet.Identity;

namespace marshall_clio_audio.Controllers
{
    [Authorize]
    public class AudioFileController : Controller
    {
        private ApplicationDbContext _dbContext;
        public AudioFileController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: AudioFile
        // the file variable collects all entries in the database and 
        //stores them as a list (using .ToList())
        //the entries are then pushed into the "Index" view page under the "AudioFile" folder in views
        public ActionResult Index()
        {
            var files = _dbContext.AudioFiles.ToList();
             return View(files);
        }

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase file, String text)
        {
            if (file != null && file.ContentLength > 0)
            {
                var ctx = new ApplicationDbContext();

                int FileLength = file.ContentLength;
                byte[] FileContents = new byte[FileLength];

                file.InputStream.Read(FileContents, 0, FileLength);

                AudioFile af = new AudioFile
                {
                    Name = text,
                    WAVData = FileContents,
                    userID = User.Identity.GetUserName(),
                    Verified = false
                };
                ctx.AudioFiles.Add(af);

                ctx.SaveChanges();

                ViewBag.Message = "File upload was successful.";
            }
            else
            {
                ViewBag.Message = "Could not upload the file.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            var ctx = new ApplicationDbContext();

            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = User.Identity.GetUserName();
            if (user == "Admin@Admin.com")
            {
                var file = _dbContext.AudioFiles.SingleOrDefault(v => v.Id == id);
            if (file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }
            return RedirectToAction("NonAdmin");
        }
        //The function to delete the file
        public ActionResult SubmitEdit(int id, String Text, Boolean truthValue)
        {
            var file = _dbContext.AudioFiles.SingleOrDefault(v => v.Id == id);
            if (file == null)
            {
                return HttpNotFound();
            }
            file.Name = Text;
            file.Verified = truthValue;
            
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        //This collects the id of the file we want to delete
        //and then passes it along to the "Delete" view
        public ActionResult Delete(int id)
        {
            var file = _dbContext.AudioFiles.SingleOrDefault(v => v.Id == id);
            if(file == null)
            {
                return HttpNotFound();
            }
            return View(file);
        }
        //The function to delete the file
        public ActionResult doDelete(int id)
        {
                var file = _dbContext.AudioFiles.SingleOrDefault(v => v.Id == id);
                if (User.Identity.GetUserName() == file.userID || User.Identity.GetUserName() == "Admin@Admin.com")
                {
                    if (file == null)
                {
                    return HttpNotFound();
                }

                _dbContext.AudioFiles.Remove(file);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
                }
            return RedirectToAction("NotYourFile");
        }

        public ActionResult NonAdmin()
        {
            return View();
        }
        public ActionResult NotYourFile()
        {
            return View();
        }
    }
}