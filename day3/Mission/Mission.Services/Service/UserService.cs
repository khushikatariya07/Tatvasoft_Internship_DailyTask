using System.ComponentModel.DataAnnotations;
using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;
using Mission.Repositories.IRepository;
using Mission.Services.IService;

namespace Mission.Services.Service
{
    public class UserService(IUserRepository userRepository, JwtService jwtService) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task<List<UserResponseModel>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

       

        

       

       

        public async Task<ResponseResult> LogiUser(UserLoginRequestModel model)
        {
            var (response, message) = await _userRepository.LogiUser(model);

            var result = new ResponseResult()
            {
                Message = (string)message
            };

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
            }
            else
            {
                result.Data = _jwtService.GenerateJwtToken((UserLoginResponseModel)response);
                result.Result = ResponseStatus.Success;
            }

            return result;
        }
    }
}
