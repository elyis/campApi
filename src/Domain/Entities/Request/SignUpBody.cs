using System.ComponentModel.DataAnnotations;
using campapi.src.Domain.Enums;

namespace campapi.src.Domain.Entities.Request
{
    public class SignUpBody
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public UserRole Role { get; set; }
        [Required]
        public string Password { get; set; }
    }
}