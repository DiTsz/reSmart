using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace reSmart.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<UserTesting> UserTestings { get; set; }

    }
}
