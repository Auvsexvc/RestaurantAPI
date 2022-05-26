using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/account")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            accountService.RegisterUser(dto);
            return Ok();
        }
    }
}
