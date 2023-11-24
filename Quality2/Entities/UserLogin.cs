using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Quality2.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Quality2.Entities
{
    public class UserLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public UserLogin(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
