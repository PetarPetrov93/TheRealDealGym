﻿using Microsoft.AspNetCore.Identity;
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

                    options.Password.RequireNonAlphanumeric = config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.Password.RequireDigit = config.GetValue<bool>("Identity:Password:RequireDigit");
                    options.Password.RequireLowercase = config.GetValue<bool>("Identity:Password:RequireLowercase");
                    options.Password.RequireUppercase = config.GetValue<bool>("Identity:Password:RequireUppercase");
                    options.Password.RequiredLength = config.GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
