using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListenAndWrite.Model.Models
{
    [Table("UserAudios")]
    public class UserAudio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [Column(TypeName = ("nvarchar"))]
        [MaxLength(128)]
        public string UserId { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public string AudioTitle { set; get; }

        [Required]
        [MaxLength(256)]
        public string Path { set; get; }

        public DateTime CreatedDate { set; get; }

        public string Text { set; get; }
        
    }
}