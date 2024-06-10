using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Review
    {
        [Key]
        public int IdReview { get; set; }
        public string Comment { get; set; }
        public double Rating { get; set; }
        public DateTime Date { get; set; }
        public DateTime PostDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
