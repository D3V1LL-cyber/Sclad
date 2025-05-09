using System.ComponentModel.DataAnnotations;

namespace Склад.Models.Auth
{
    public class AuthUser
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
        [Required]
        public string Role { get; set; } = "User";
    }
}
