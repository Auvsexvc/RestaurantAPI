using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class RegisterUserDto
    {
        [MinLength(9)]
        [MaxLength(500)]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Nationality { get; set; }
        public int RoleId { get; set; } = 4;
    }
}