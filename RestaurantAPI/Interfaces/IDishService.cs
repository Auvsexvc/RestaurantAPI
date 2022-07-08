using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Interfaces
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);

        List<DishDto> GetAll(int restaurantId);

        DishDto GetById(int restaurantId, int dishId);

        void RemoveAll(int restaurantId);

        void Update(int restaurantId, int dishId, UpdateDishDto dto);
    }
}