using Microsoft.AspNetCore.Mvc;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;
using Mission.Services.IService;

namespace Mission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginRequestModel model) 
        {
            var response = await _userService.LogiUser(model);

            if (response.Result == ResponseStatus.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(AddUserRequestModel model)
        {
            var response = await _userService.RegisterUserAsync(model);

            var result = new ResponseResult();

            if (!response)
            {
                result.Message = "User already exist with same email address";
                result.Result = ResponseStatus.Error;
                return BadRequest(result);
            }

            result.Result = ResponseStatus.Success;
            return Ok(result);
        }
    }
}
