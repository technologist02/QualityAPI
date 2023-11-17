using Quality2.IRepository;

namespace Quality2.ViewModels
{
    public class UserRegisterView: IUser
    {
        public string Login { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
