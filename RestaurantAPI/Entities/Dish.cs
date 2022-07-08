namespace RestaurantAPI.Entities
{
    public class Dish
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}