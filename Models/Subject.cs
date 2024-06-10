namespace reSmart.Models
{
    public class Subject
    {
        [Key]
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
