using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using marshall_clio_audio.Models;

namespace marshall_clio_audio.Controllers
{
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
            if(file == null)
            {
                return HttpNotFound();
            }

            _dbContext.AudioFiles.Remove(file);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}