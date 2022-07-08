using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Interfaces
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);

        void Delete(int id);

        IEnumerable<RestaurantDto> GetAll();

        RestaurantDto GetById(int id);

        void Update(int id, UpdateRestaurantDto dto);
    }
}