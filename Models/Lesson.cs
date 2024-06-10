using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Lesson
    {
        [Key]
        public int IdLesson { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UrlLection { get; set; }

        public Course Course { get; set; }
        public ICollection<Content> Contents { get; set; }
    }

}
