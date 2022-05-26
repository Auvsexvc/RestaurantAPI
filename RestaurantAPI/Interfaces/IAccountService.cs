using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }
}