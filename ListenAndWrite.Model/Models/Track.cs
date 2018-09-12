using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListenAndWrite.Model.Models
{
    [Table("Tracks")]
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required]
        public int AudioId { get; set; }

        [Required]
        [MaxLength(256)]
        public string TrackTitle { get; set; }

        [Required]
        [MaxLength(256)]
        public string Answer { get; set; }

        [Required]
        public int TimeStart { get; set; }

        [Required]
        public int Duration { get; set; }

        [ForeignKey("AudioId")]
        public virtual Audio Audio { set; get; }
    }
}