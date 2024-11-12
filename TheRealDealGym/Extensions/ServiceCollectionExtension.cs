using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISportService, SportService>();
            services.AddScoped<IJobService, JobService>();
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            
            var connectionString = config.GetConnectionString("DefaultConnection");

            //The below code is implemented purely for presentaton purposes to display the diferences when in Production
            var environmentName = config["ASPNETCORE_ENVIRONMENT"];

            if (environmentName == "Production")
            {
                connectionString = "Server=.;Database=TheRealDealGym;Trusted_Connection=True;Trust Server Certificate=true;";
            }
            //

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

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
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
