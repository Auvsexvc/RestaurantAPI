using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.DataSeeders
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = new()
            {
                new Restaurant()
                {
                    Name =  "KFC",
                    Category = "Fast Food",
                    Description = "KFC description",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description = "MCD description",
                    ContactEmail = "contact@mcd.com",
                    HasDelivery = false,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "McRoyal with Cheese",
                            Price = 10.30M,
                        },
                        new Dish()
                        {
                            Name = "Cheese Burger",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Krótka 5",
                        PostalCode = "30-001"
                    }
                }
            };
            return restaurants;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect() && !_dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                _dbContext.Restaurants.AddRange(restaurants);
                _dbContext.SaveChanges();
            }
        }
    }
}