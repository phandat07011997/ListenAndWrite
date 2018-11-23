using System;

namespace ListenAndWrite.Web.Models
{
    public class UserAudioViewModel
    {
        
        public int Id { set; get; }

        public string UserId { set; get; }

        public string AudioTitle { set; get; }

        public string Path { set; get; }

        public DateTime CreatedDate { set; get; }

        public string Text { set; get; }
    }
}