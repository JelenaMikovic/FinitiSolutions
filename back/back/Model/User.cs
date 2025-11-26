using System.ComponentModel.DataAnnotations;

namespace nvt_back
{
    public enum UserRole
    {
        USER,
        ADMIN
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
