using FACL_Locker_Room_API.Core.DTOs;
using FACL_Locker_Room_API.Core.Interfaces;
using FACL_Locker_Room_API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FACL_Locker_Room_API.Controllers
{

    [ApiController]
    [Route("api/V1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices userServices;
        private readonly IConfiguration Configuration;

        public UserController(IUserServices userServices, IConfiguration configuration)
        {
            this.userServices = userServices;
            this.Configuration = configuration;
        }
        [HttpGet("get-current-version")]
        public  IActionResult GetCurrentVersion()
        {
            string version = this.Configuration.GetSection("config")["AppVersion"];
            return version == null ? NotFound() : Ok(version);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccount(CreateAccountDTO user)
        {
            var userObject = await userServices.CreateAccount(user);
            return Ok(userObject);  
        }
        [HttpGet("get-account")]
        public async Task<IActionResult> GetAccount([FromQuery] GetAccountDTO user)
        {
            var userObject = await userServices.GetAcccount(user);
            return Ok(userObject);
        }
    }
}
