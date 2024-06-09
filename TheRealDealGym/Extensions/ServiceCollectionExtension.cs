using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Infrastructure.Data;
using TheRealDealGym.Infrastructure.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<ApplicationUser>(options => 
                { 
                    options.SignIn.RequireConfirmedAccount = config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                    options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:SignIn:RequireNonAlphanumeric");
                    options.Password.RequireDigit = config.GetValue<bool>("Identity:SignIn:RequireDigit");
                    options.Password.RequireLowercase = config.GetValue<bool>("Identity:SignIn:RequireLowercase");
                    options.Password.RequireUppercase = config.GetValue<bool>("Identity:SignIn:RequireUppercase");
                    options.Password.RequiredLength = config.GetValue<int>("Identity:SignIn:RequiredLength");
                })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
