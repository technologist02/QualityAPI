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
using Quality2.Exceptions;

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
            
            user.Validate();
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
                await db.Users
                .Include(x => x.Roles)
                .SingleOrDefaultAsync(x => x.Login == login.Login)
                :
                await db.Users
                .Include(x => x.Roles)
                .SingleOrDefaultAsync(x => x.Email == login.Login);
            if (userDto is null) { return string.Empty; }
            var verify = BCrypt.Net.BCrypt.Verify(login.Password, userDto.PasswordHash);
            //var rolesDto = await db.Roles.Where(x => x.RoleIdUser == userDto.ID).ToListAsync();
            Console.WriteLine(verify);
            if (verify)
            {
                var user = Mapper.Map<User>(userDto);
                var roles = Mapper.Map<List<Role>>(userDto.Roles);
                return AuthOptions.CreateToken(user, roles);
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
                var userDto = await db.Users
                    .SingleOrDefaultAsync(x => x.Login == userLogin);
                return Mapper.Map<User>(userDto);
            }
            else return null;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            using var db = new DataContext();
            var rolesDto = await db.Roles.ToListAsync();
            return Mapper.Map<List<Role>>(rolesDto);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using var db = new DataContext();
            var usersDto = await db.Users
                .Include(x => x.Roles)
                .ToListAsync();
            return Mapper.Map<List<User>>(usersDto);
        }

        public async Task UpdateUserRolesAsync(UpdateUserRolesView user)
        {
            using var db = new DataContext();
            var userDto = await db.Users
                .Include(x => x.Roles)
                .SingleOrDefaultAsync(x => x.UserId == user.UserId);
            if (userDto != null)
            {
                var roles = await db.Roles
                    .Where(x => user.RoleIds.Contains(x.RoleId)).ToListAsync();
                var removeList = userDto.Roles != null ? userDto.Roles.Except(roles).ToList() : new List<RoleDto>();
                var addList = userDto.Roles != null ? roles.Except(userDto.Roles).ToList() : roles;
                userDto.Roles?
                    .RemoveAll(x => removeList.Contains(x));
                userDto.Roles
                    .AddRange(addList);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateUserDataAsync(User user)
        {
            user.Validate();
            var authData = httpContextAccessor?.HttpContext?.User?.Identity;
            if (authData != null && authData.IsAuthenticated)
            {
                var userLogin = authData.Name;
                if (userLogin == user.Login)
                {
                    using var db = new DataContext();
                    var userDto = await db.Users
                        .SingleOrDefaultAsync(x => x.Login == userLogin);
                    userDto.Email = user.Email;
                    userDto.Name = user.Name;
                    userDto.Surname = user.Surname;
                    await db.SaveChangesAsync();
                }
                else throw new BadRequestException("Вы не можете изменить даннные других пользователей");
            }
        }
    }
}
