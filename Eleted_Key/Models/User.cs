using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Eleted_Key.Models
{
    public class User 
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
