using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateDishDto
    {
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}