using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListenAndWrite.Web.Models
{
    public class ScoreViewModel
    {
        public int Id { set; get; }
        public int AudioId { get; set; }
        public int AudioScore { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual AudioViewModel Audio { set; get; }
    }
}