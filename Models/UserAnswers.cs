using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class UserAnswers
    {
        [Key]
        public int IdUserAnswers { get; set; }

        [ForeignKey("UserTesting")]
        public int UserTestingId { get; set; }
        public UserTesting UserTesting { get; set; }

        [ForeignKey("Answer")]
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public Answer Answer { get; set; }
    }
}
