using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Interfaces
{
    public interface IRestaurantService
    {
        RestaurantDto GetById(int id);

        IEnumerable<RestaurantDto> GetAll();

        int Create(CreateRestaurantDto dto);

        void Delete(int id);

        void Update(int id, UpdateRestaurantDto dto);
    }
}