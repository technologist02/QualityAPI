using Quality2.Entities;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IUserService
    {
        public Task RegisterUserAsync(UserRegisterView user);

        public Task<string> LoginUserAsync(UserLogin login);

        public Task<User?> GetUserDataAsync();

        public Task<List<User>> GetAllUsersAsync();

        public Task<List<Role>> GetRolesAsync();

        public Task UpdateUserRolesAsync(UpdateUserRolesView user);

    }
}
