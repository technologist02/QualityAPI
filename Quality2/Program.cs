using Quality2.Database;
using Quality2.IRepository;
using Quality2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Quality2.AutoOptions;

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
                    ValidIssuer = AuthOptions.ISSUER,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true,
                });
                                                                          // подключение аутентификации с помощью jwt-токенов            // добавление сервисов авторизации
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            

            app.MapControllers();
            app.Run();
        }
    }
}