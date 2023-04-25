using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions {
    public static class ApplicationServiceExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) {
            //this IServiceCollection services, is the thing being extended

            services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString("DefaultConnection")); //Looks in the "appsettings" file
            });

            services.AddCors();
            //section 4.41 udemy
            services.AddScoped<ITokenService, TokenService>(); //usually what you want
            // services.AddTransient() very short lived
            // services.AddSingleton() is run at startup and persists until the app is closed. used when you want to cache data to improve load times

            services.AddScoped<IUserRepository, UserRepository>(); //means this is scoped to the level of the Http Request
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //sec 8.94, ~5 min
            return services;
        }
    }
}