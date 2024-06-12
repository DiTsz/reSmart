using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string Language { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
