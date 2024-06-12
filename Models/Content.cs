using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Content
    {
        [Key]
        public int IdContent { get; set; }

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Lesson Lesson { get; set; }

        public string Purpose { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }
        public string FileSize { get; set; }
    }
}
