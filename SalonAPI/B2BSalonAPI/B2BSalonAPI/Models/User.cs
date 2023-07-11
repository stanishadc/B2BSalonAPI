using Microsoft.AspNetCore.Identity;

namespace B2BSalonAPI.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? OTP { get;set; }
        public DateTime? OTPExpire { get; set; }
    }
}
