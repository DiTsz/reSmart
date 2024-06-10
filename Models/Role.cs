namespace reSmart.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string RoleTitle { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
