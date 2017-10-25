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
        public ActionResult Index()
        {
            var audioFile = _dbContext.AudioFiles.ToList();

            return View(audioFile);
        }
    }
}