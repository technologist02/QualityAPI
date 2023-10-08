using Quality2.Database;
using Quality2.IRepository;
using Quality2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Quality2.AutorizationService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Quality2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>();
            builder.Services.AddTransient<IFilmService, FilmService>();
            builder.Services.AddTransient<IExtrudersService, ExtrudersService>();
            builder.Services.AddTransient<IOrderQuailtyService, OrderQualityService>();
            builder.Services.AddTransient<IStandartQualityNameService, StandartQualityNameService>();
            builder.Services.AddTransient<IStandartQualityFilmService, StandartQualityFilmService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    // строка, представляющая издателя
                    ValidIssuer = AutorizationService.AuthorizationOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AutorizationService.AuthorizationOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AutorizationService.AuthorizationOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                });
                                                                          // подключение аутентификации с помощью jwt-токенов
            builder.Services.AddAuthorization();            // добавление сервисов авторизации
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            

            app.MapControllers();
            //app.Map("/login/{username}", (string username) =>
            //{
            //    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
            //    var jwt = new JwtSecurityToken(
            //            issuer: AutorizationService.AuthorizationOptions.ISSUER,
            //            audience: AutorizationService.AuthorizationOptions.AUDIENCE,
            //            claims: claims,
            //    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)), // время действия 2 минуты
            //            signingCredentials: new SigningCredentials(AutorizationService.AuthorizationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            //    return new JwtSecurityTokenHandler().WriteToken(jwt);
            //});

            app.Run();
        }
    }
}