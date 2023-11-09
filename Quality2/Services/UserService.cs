using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.PasswordService;
using System.Security.Claims;
using Quality2.AutoOptions;
using Quality2.IRepository;
using Quality2.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Quality2.Services
{
    public class UserService: IUserService
    {
        private static readonly IMapper Mapper;
        static UserService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entities.User, UserDto>();
                config.CreateMap<UserDto, Entities.User>();
                config.CreateMap<UserRegisterView, UserDto>();
            }).CreateMapper();
        }

        public async Task RegisterUserAsync(UserRegisterView user)
        {
            //PasswordSettings.CreatePasswordHash(user.Password, out var passHash, out var passSalt);
            
            using var db = new DataContext();
            var dbModel = Mapper.Map<UserDto>(user);
            var hash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            dbModel.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await db.UsersDto.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<string> LoginUserAsync(UserLogin login)
        {
            using var db = new DataContext();
            var userDto = !login.Login.Contains('@') ?
                await db.UsersDto.FirstOrDefaultAsync(x => x.Login == login.Login)
                :
                await db.UsersDto.FirstOrDefaultAsync(x => x.Email == login.Login);
            if (userDto is null) { return string.Empty; }
            var user = Mapper.Map<Entities.User>(userDto);
            var verify = BCrypt.Net.BCrypt.Verify(login.Password, userDto.PasswordHash);
            Console.WriteLine(verify);
            if (verify)
            {
                return AuthOptions.CreateToken(user);
            }
            else return string.Empty;
        }

        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public UserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}
        //public IEnumerable<Claim> GetUserData()
        //{
        //    var userData = _httpContextAccessor.HttpContext.User;
        //    if (userData is not null && userData.Identity.IsAuthenticated)
        //    {
        //        return userData.Claims;
        //    }
        //    return new List<Claim>();
        //}
    }
}
