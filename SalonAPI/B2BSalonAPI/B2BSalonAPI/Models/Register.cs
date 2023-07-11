using System.ComponentModel.DataAnnotations;

namespace B2BSalonAPI.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
