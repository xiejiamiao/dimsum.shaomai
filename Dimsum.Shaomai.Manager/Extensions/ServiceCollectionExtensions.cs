using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Manager.Infrastructure.Authorize;
using Dimsum.Shaomai.Repository;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dimsum.Shaomai.Manager.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMySqlDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DomainContext>(options => { options.UseMySql(configuration["MySql"]); });
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManagerUserRepository, ManagerUserRepository>();
            services.AddScoped<ISolutionRepository, SolutionRepository>();
            services.AddScoped<ISolutionEnvRepository, SolutionEnvRepository>();
            return services;
        }

        public static IServiceCollection AddShaomaiMediator(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Program).Assembly);
        }

        public static IServiceCollection AddShaomaiAuthentication(this IServiceCollection services,IConfiguration configuration)
        {
            var loginPath = configuration["LoginPath"];
            services.AddScoped<HttpAuthorizeHandler>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = "/user/login";
                });
            return services;
        }
    }
}
