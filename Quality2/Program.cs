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
using Microsoft.OpenApi.Models;
using Quality2.Middlewares;
using NLog.Web;
using NLog;
using System;
using NLog.Extensions.Logging;

namespace Quality2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            //logger.Debug("init main");

            //try
            //{
                var builder = WebApplication.CreateBuilder(args);
                // Add services to the container.
                builder.Services.AddControllers();
                //builder.Logging.ClearProviders();
                //builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                //builder.Host.UseNLog();
                builder.Services.AddDbContext<DataContext>();
                builder.Services.AddTransient<IFilmService, FilmService>();
                builder.Services.AddTransient<IExtrudersService, ExtrudersService>();
                builder.Services.AddTransient<IOrderQuailtyService, OrderQualityService>();
                builder.Services.AddTransient<IStandartQualityTitleService, StandartQualityTitleService>();
                builder.Services.AddTransient<IStandartQualityFilmService, StandartQualityFilmService>();
                builder.Services.AddTransient<IUserService, UserService>();
                builder.Services.AddHttpContextAccessor();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(op =>
                {
                    op.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });
                    op.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                        {
                          new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                  });
                });
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
                        ValidateLifetime = true,
                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    });
                builder.Services.AddAuthorization();
                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseCustomErrorsHandler();
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.MapControllers();
                app.Run();
            //}
            
            //catch (Exception exception)
            //{
            //    // NLog: catch setup errors
            //    logger.Error(exception, "Stopped program because of exception");
            //    throw;
            //}
            //finally
            //{
            //    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            //    NLog.LogManager.Shutdown();
            //}
        }
    }
}