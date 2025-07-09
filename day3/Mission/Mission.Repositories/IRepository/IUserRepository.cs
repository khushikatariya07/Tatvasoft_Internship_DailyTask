using Mission.Entities.ViewModels;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;

namespace Mission.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<ResponseResult> LogiUser(UserLoginRequestModel model);

        Task<List<UserResponseModel>> GetUsersAsync();

       
    }
}
