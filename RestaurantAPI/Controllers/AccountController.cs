using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var userDtos = _accountService.GetAll();
            return Ok(userDtos);
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
    }
}