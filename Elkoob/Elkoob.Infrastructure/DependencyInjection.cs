using System;
using System.Collections.Generic;
using System.Text;
using Elkoob.Application.Common.Interfaces;
using Elkoob.Domain.Interfaces;
using Elkoob.Infrastructure.Data;
using Elkoob.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elkoob.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            #region DB Context

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            #region Identity

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            #region IoC

            services.AddScoped<IApplicationDbContext>(
                provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            return services;
        }
    }
}
