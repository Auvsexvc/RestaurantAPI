using System;

namespace RestaurantAPI.Entities
{
    public class User
    {
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string PasswordHash { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
    }
}