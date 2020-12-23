using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealPage.Properties.Application.Interface;
using RealPage.Properties.Application.Main;
using RealPage.Properties.Domain.Core;
using RealPage.Properties.Domain.Interface;
using RealPage.Properties.Infrastructure.Interface;
using RealPage.Properties.Infrastructure.Repository;
using RealPage.Properties.Transversal.Common;
using RealPage.Properties.Transversal.Logging;
namespace RealPage.Properties.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IPropertiesApplication, PropertiesApplication>();
            services.AddScoped<IPropertiesDomain, PropertiesDomain>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("PropertyConnection")));
            return services;
        }
    }
}
