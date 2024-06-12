using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Question
    {
        [Key]
        public int IdQuestion { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }

        public string QuestionText { get; set; }
        public string Type { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
