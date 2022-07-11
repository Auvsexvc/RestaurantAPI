using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class UpdateDishDto
    {
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
