using GoldDuckCamera.Server.Models;
using GoldDuckCamera.Server.Repository;

namespace GoldDuckCamera.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _user;
        public UserService(IUserRepository<User> user)
        {
            _user = user;
        }
        public async Task<User> AddUser(User user)
        {
            return await _user.CreateAsync(user);
        }

        public async Task<bool> UpdateUser(string username, User user)
        {
            var data = await _user.GetByIdAsync(username);

            if (data != null)
            {
                data.password = user.password;
                data.fullname = user.fullname;
                data.date = user.date;
                data.gender = user.gender;
                data.address = user.address;
                data.phone = user.phone;
                data.idPermission = user.idPermission;
                data.status = user.status;

                await _user.UpdateAsync(data);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> DeleteUser(string username)
        {
            await _user.DeleteAsync(username);
            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _user.GetAllAsync();
        }

        public async Task<User> GetUser(string username)
        {
            return await _user.GetByIdAsync(username);
        }
    }
}
