using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Quality2.AutorizationService
{
    public class AuthorizationOptions
    {
        public const string ISSUER = "QualityService"; // издатель токена
        public const string AUDIENCE = "QualityUI"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123ForLongerKey";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
