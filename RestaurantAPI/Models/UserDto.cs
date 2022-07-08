using RestaurantAPI.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string RoleName { get; set; }
    }
}
