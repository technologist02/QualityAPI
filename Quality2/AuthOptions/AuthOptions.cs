using Microsoft.IdentityModel.Tokens;
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


        public static string CreateToken(Entities.User user)
        {
            List<Claim> claims = new()
    {
        new Claim(ClaimTypes.SerialNumber, user.ID.ToString()),
        new Claim(ClaimTypes.UserData, user.Login),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Surname, user.Surname),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var key = GetSymmetricSecurityKey();
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
