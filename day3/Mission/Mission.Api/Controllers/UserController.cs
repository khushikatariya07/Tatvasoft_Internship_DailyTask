using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpGet]
        [Route("UserDetailList")]
        public async Task<IActionResult> GetUserDetailList()
        {
            var response = await _userService.GetUsersAsync();

            var result = new ResponseResult() { Data = response, Result = ResponseStatus.Success };

            return Ok(result);
        }

        
        
    }
}
