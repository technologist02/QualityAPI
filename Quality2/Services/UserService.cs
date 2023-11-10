using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using System.Security.Claims;
using Quality2.AutoOptions;
using Quality2.IRepository;
using Quality2.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Quality2.Services
{
    public class UserService: IUserService
    {
        private static readonly IMapper Mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        static UserService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Role, RoleDto>();
                config.CreateMap<RoleDto, Role>();
                config.CreateMap<User, UserDto>();
                config.CreateMap<UserDto, User>();
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
            dbModel.Created = DateTime.UtcNow;
            await db.Users.AddAsync(dbModel);
            await db.SaveChangesAsync();
        }

        public async Task<string> LoginUserAsync(UserLogin login)
        {
            using var db = new DataContext();
            var userDto = !login.Login.Contains('@') ?
                await db.Users.FirstOrDefaultAsync(x => x.Login == login.Login)
                :
                await db.Users.FirstOrDefaultAsync(x => x.Email == login.Login);
            if (userDto is null) { return string.Empty; }
            //var rolesDto = await db.Roles.Where(x => x.User == userDto.ID).ToListAsync();
            var user = Mapper.Map<User>(userDto);
            //var roles = Mapper.Map<List<Role>>(rolesDto);
            var verify = BCrypt.Net.BCrypt.Verify(login.Password, userDto.PasswordHash);
            Console.WriteLine(verify);
            if (verify)
            {
                return AuthOptions.CreateToken(user);
            }
            else return string.Empty;
        }

        public async Task<User?> GetUserDataAsync()
        {
            var authData = httpContextAccessor?.HttpContext?.User?.Identity;
            if (authData != null && authData.IsAuthenticated)
            {
                var userLogin = authData.Name;
                using var db = new DataContext();
                var userDto = await db.Users.FirstOrDefaultAsync(x => x.Login == userLogin);
                return Mapper.Map<User>(userDto);
            }
            else return null;
            
        }
    }
}
