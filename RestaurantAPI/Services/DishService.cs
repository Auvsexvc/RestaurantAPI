using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<DishService> _logger;

        public DishService(RestaurantDbContext context, IMapper mapper, ILogger<DishService> logger)
        {
            _dbContext = context;
            _mapper = mapper;
            _logger = logger;
        }

        public int Create(int restaurantId, CreateDishDto dto)
        {
            Dish newDish = _mapper.Map<Dish>(dto);

            newDish.RestaurantId = restaurantId;

            _dbContext.Dishes.Add(newDish);
            _dbContext.SaveChanges();

            _logger.LogInformation($"Dish with ID: {newDish.Id} created");
            return newDish.Id;
        }

        public void Delete(int restaurantId, int dishId)
        {
            Dish dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);

            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }
            else if (dish.RestaurantId != restaurantId)
            {
                throw new BadRequestException("Bad Request");
            }

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();

            _logger.LogInformation($"Dish with ID: {dish.Id} deleted");
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            Restaurant restaurant = GetRestaurantById(restaurantId);

            return _mapper.Map<List<DishDto>>(restaurant.Dishes);
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            Dish dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);

            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }
            else if (dish.RestaurantId != restaurantId)
            {
                throw new BadRequestException("Bad Request");
            }

            return _mapper.Map<DishDto>(dish);
        }

        public void RemoveAll(int restaurantId)
        {
            Restaurant restaurant = GetRestaurantById(restaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            _dbContext.RemoveRange(restaurant.Dishes);
            _dbContext.SaveChanges();

            _logger.LogWarning($"All dishes from restaurant {restaurant.Id} have been removed!!!");
        }

        public void Update(int restaurantId, int dishId, UpdateDishDto dto)
        {
            Dish dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);

            if (dish is null)
            {
                throw new NotFoundException("Dish not found");
            }
            else if (dish.RestaurantId != restaurantId)
            {
                throw new BadRequestException("Bad Request");
            }

            dish.Name = dto.Name;
            dish.Description = dto.Description;
            dish.Price = dto.Price;
            _dbContext.SaveChanges();

            _logger.LogInformation($"Dish with ID: {dish.Id} updated");
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            Restaurant restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            return restaurant;
        }
    }
}