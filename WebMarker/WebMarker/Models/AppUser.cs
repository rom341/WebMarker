using System.ComponentModel.DataAnnotations;

namespace WebMarker.Models
{
    public class AppUser
    {
        [Key]
        public long Id { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public AppUser()
        {
            Login = "";
            Password = "";
            Email = "";
        }
    }
}
