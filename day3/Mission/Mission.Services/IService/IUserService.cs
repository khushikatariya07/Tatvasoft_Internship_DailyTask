using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;

namespace Mission.Services.IService
{
    public interface IUserService
    {
        Task<ResponseResult> LogiUser(UserLoginRequestModel model);

        Task<List<UserResponseModel>> GetUsersAsync();

      
    }
}
