using Microsoft.IdentityModel.Tokens;
using Quality2.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Quality2.AutoOptions
{
    public class AuthOptions
    {
        public const string ISSUER = "QualityService"; // издатель токена
        public const string AUDIENCE = "QualityUI"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123ForLongerKey";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));


        public static string CreateToken(User user, List<Role> roles)
        {
            List<Claim> claims = new()
            {
                //new Claim(ClaimTypes.SerialNumber, user.ID.ToString()),
                //new Claim(ClaimTypes.UserData, user.Login),
                new Claim(ClaimTypes.Name, user.Login),
                //new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Function));
            }

            var key = GetSymmetricSecurityKey();
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: ISSUER,
                audience: AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
