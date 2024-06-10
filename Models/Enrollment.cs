using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Enrollment
    {
        [Key]
        public int IdEnrollment { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }


        public User User { get; set; }
        public Course Course { get; set; }
    }
}
