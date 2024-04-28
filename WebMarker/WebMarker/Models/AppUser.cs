using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebMarker.Models
{
    public class AppUser : IdentityUser
    {
        public string Password { get; set; }

        public AppUser()
        {
            Password = "";
        }
    }
}
