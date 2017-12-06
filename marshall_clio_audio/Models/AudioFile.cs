using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace marshall_clio_audio.Models
{
    public class AudioFile
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public byte[] WAVData { get; set; }
        public String userID { get; set; }
        public Boolean Verified { get; set; }
    }
}