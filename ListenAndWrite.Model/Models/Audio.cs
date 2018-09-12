using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListenAndWrite.Model.Models
{
    [Table("Audios")]
    public class Audio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public string AudioTitle { set; get; }

        [Required]
        [MaxLength(256)]
        public string Path { set; get; }

        [Required]
        public int Level { set; get; }

        [Required]
        public int Duration { set; get; }

        [MaxLength(500)]
        public string Description { set; get; }

        [MaxLength(256)]
        public string CreatedBy { set; get; }

        public DateTime CreatedDate { set; get; }

        [MaxLength(256)]
        public string UpdateBy { set; get; }

        public DateTime UpdateDate { set; get; }

        public bool Status { set; get; }

        public virtual IEnumerable<Track> Tracks { set; get; }

        public virtual IEnumerable<Score> Scores { set; get; }
    }
}