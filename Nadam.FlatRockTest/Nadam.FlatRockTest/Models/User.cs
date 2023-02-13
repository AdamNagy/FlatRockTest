using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace Nadam.FlatRockTest.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; } = "";
        public bool IsAdmin { get; set; }
        public GameMode GameMode { get; set; }

        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
