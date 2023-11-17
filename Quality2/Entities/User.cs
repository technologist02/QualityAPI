using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Quality2.Exceptions;
using Quality2.IRepository;
using Quality2.ViewModels;
using System.Text.RegularExpressions;

namespace Quality2.Entities
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; }
        public List<Role>? Roles { get; set; }
        public DateTime Created { get; set; }

    }
}
