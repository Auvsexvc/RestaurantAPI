using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using System.Linq;

namespace RestaurantAPI.Models.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);
        }
    }
}
