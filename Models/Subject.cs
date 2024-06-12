namespace reSmart.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }

        public string SubjectName { get; set; }
        public string Description { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
