using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListenAndWrite.Web.Models
{
    public class TrackViewModel
    {
        public int Id { set; get; }
        public int AudioId { get; set; }
        public int Order { get; set; }
        public string Answer { get; set; }
        public float TimeStart { get; set; }
        public float Duration { get; set; }
        public virtual AudioViewModel Audio { set; get; }
    }
}