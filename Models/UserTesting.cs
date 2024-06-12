using System.ComponentModel.DataAnnotations.Schema;

namespace reSmart.Models
{
    public class UserTesting
    {
        [Key]
        public int IdUserTesting { get; set; }

        public DateTime PassDate { get; set; }
        public int Result { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }

        public ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
