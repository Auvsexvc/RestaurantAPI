using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(RestaurantDbContext context, IPasswordHasher<User> passwordHasher, IMapper mapper, ILogger<AccountService> logger, AuthenticationSettings authenticationSettings)
        {
            _dbContext = context;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _logger = logger;
            _authenticationSettings = authenticationSettings;
        }

        public string GenereateJWT(LoginDto dto)
        {
            var user = _dbContext
                .Users
                .Include(u=>u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if(user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if(result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
                new Claim("Nationality", user.Nationality)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiresOn = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, _authenticationSettings.JwtIssuer, claims, expires: expiresOn, signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
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