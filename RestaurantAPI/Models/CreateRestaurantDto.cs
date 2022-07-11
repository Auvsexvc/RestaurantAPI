using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateRestaurantDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactNumber { get; set; }





        [Required]
        [MaxLength(25)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}