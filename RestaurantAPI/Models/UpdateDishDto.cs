using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class UpdateDishDto
    {
        [MaxLength(500)]
        public string Description { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
