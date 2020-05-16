using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WastelessAPI.Application.Logic;
using WastelessAPI.Application.Observer;
using WastelessAPI.Commands;
using WastelessAPI.DataAccess;
using WastelessAPI.DataAccess.Interfaces;
using WastelessAPI.DataAccess.Repositories;
using WastelessAPI.Handlers;
using WastelessAPI.Mediator;
using WastelessAPI.Queries;

namespace WastelessAPI
{
    public class Startup
    {
        private IConfiguration _config { get; }

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<UserRepository>();
            services.AddTransient<IGroceriesRepository, GroceriesRepository>();
            services.AddTransient<CharitiesRepository>();
            services.AddTransient<UserLogic>();
            services.AddTransient<GroceriesLogic>();
            services.AddTransient<CharitiesLogic>();
            services.AddTransient<PushNotificationObserver>();

            services.AddTransient<IMediator, Mediator.Mediator>();

            services.AddTransient<GetCharitiesQuery>();
            services.AddTransient<GetGroceriesQuery>();
            services.AddTransient<GetNotificationQuery>();
            services.AddTransient<GetReportQuery>();
            services.AddTransient<RegisterUserCommand>();
            services.AddTransient<LoginUserCommand>();

            services.AddTransient<GetCharitiesHandler>();
            services.AddTransient<GetGroceriesHandler>();
            services.AddTransient<GetNotificationHandler>();
            services.AddTransient<GetReportHandler>();
            services.AddTransient<RegisterUserHandler>();
            services.AddTransient<LoginUserHandler>();

            services.AddDbContext<WastelessDbContext>(options => options.UseMySql(_config.GetConnectionString("WASTELESS_DB")));
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = _config["Jwt:Issuer"],
                     ValidAudience = _config["Jwt:Issuer"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
                 };
             });

            services.AddCors();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseCors(options => options.WithOrigins(_config.GetSection("RequestOrigin").Value)
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
