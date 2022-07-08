using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class UpdateRestaurantDto
    {
        public string Description { get; set; }

        public bool HasDelivery { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}