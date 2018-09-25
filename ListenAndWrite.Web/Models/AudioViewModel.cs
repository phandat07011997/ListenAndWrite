using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListenAndWrite.Web.Models
{
    public class AudioViewModel
    {
        public int Id { set; get; }
        public string AudioTitle { set; get; }
        public string Path { set; get; }
        public int Level { set; get; }
        public int Duration { set; get; }
        public int NumTrack { set; get; }
        public string Description { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public string UpdateBy { set; get; }
        public DateTime? UpdateDate { set; get; }
        public bool Status { set; get; }
        public virtual IEnumerable<TrackViewModel> Tracks { set; get; }
        public virtual IEnumerable<ScoreViewModel> Scores { set; get; }
    }
}