using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class Answer
    {
        [Key]
        public int IdAnswer { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }


        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        public ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
