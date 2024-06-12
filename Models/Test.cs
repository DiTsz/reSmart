namespace reSmart.Models
{
    public class Test
    {
        [Key]
        public int IdTest { get; set; }

        public string TestName { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<UserTesting> UserTestings { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
