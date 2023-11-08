using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IUserService
    {
        public Task RegisterUserAsync(Entities.User user);

        public Task<string> LoginUserAsync(Login login);

    }
}
