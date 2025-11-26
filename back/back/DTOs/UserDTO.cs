using System.Data;

namespace nvt_back.DTOs
{
    internal class UserDTO
    {

        public string Email { get; set; }
        public UserRole Role { get; set; }


        public UserDTO(User user)
        {
            this.Email = user.Email;
            this.Role = user.Role;
        }
    }
}