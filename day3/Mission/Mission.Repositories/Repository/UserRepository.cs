using Microsoft.EntityFrameworkCore;
using Mission.Entities;
using Mission.Entities.Models;
using Mission.Entities.ViewModels.Login;
using Mission.Entities.ViewModels.User;
using Mission.Repositories.IRepository;

namespace Mission.Repositories.Repository
{
    public class UserRepository(MissionDbContext dbContext) : IUserRepository
    {
        private readonly MissionDbContext _context = dbContext;

        public async Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model) 
        {
            var user = await _context.Users.Where(u => u.EmailAddress.ToLower() == model.EmailAddress.ToLower()).FirstOrDefaultAsync();

            if (user == null)
            {
                return (null, "User doesn't exist for the given emailaddress");
            }

            if (user.Password != model.Password)
            {
                return (null, "Password doesn't matched");
            }

            var response = new UserLoginResponseModel() 
            {
                Id = user.Id,
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
                UserImage = user.UserImage,
            };

            return (response, "Login Successfully");
        }

        public async Task<List<UserResponseModel>> GetUsersAsync()
        {
            return await _context.Users.Select(u => new UserResponseModel()
            {
                Id = u.Id,
                EmailAddress = u.EmailAddress,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                UserType = u.UserType,
                ProfileImage = u.UserImage,
            }).ToListAsync();
        }

     

       
      

    }
}
