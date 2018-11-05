using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListenAndWrite.Model.Models
{
    [Table("Scores")]
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        [Column(TypeName =("nvarchar"))]
        [MaxLength(128)]
        public string UserId { set; get; }

        [Required]
        public int AudioId { get; set; }

        [Required]
        public float AudioScore { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey("AudioId")]
        public virtual Audio Audio { set; get; }
    }
}