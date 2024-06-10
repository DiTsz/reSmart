using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class UserAnswers
    {
        [Key]
        public int IdUserAnswers { get; set; }

        [ForeignKey("UserTesting")]
        public int UserTestingId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }

        public UserTesting UserTesting { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
        public Test Test { get; set; }
    }

}
