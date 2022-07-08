using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;

        public AccountService(RestaurantDbContext context, IPasswordHasher<User> passwordHasher, IMapper mapper, ILogger<AccountService> logger)
        {
            _dbContext = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<UserDto> GetAll()
        {
            List<User> users = _dbContext
                .Users
                .Include(r => r.Role)
                .ToList();

            return _mapper.Map<List<UserDto>>(users);
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            User newUser = new()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId,
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, dto.Password);
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            _logger.LogInformation($"User with ID: {newUser.Id} created");
        }
    }
}