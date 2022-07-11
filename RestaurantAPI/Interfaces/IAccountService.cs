using RestaurantAPI.Models;
using System.Collections;
using System.Collections.Generic;

namespace RestaurantAPI.Interfaces
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        IEnumerable<UserDto> GetAll();

        string GenereateJWT(LoginDto dto);
    }
}