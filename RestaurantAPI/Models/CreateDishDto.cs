using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class CreateDishDto
    {
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
    }
}