using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateRestaurantDto
    {
        public string Category { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactNumber { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public bool HasDelivery { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string PostalCode { get; set; }

        [Required]
        [MaxLength(25)]
        public string Street { get; set; }
    }
}