using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimsum.Shaomai.Infrastructure;
using Dimsum.Shaomai.IRepository;
using Dimsum.Shaomai.Repository;
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
            services.AddScoped<IManagerUserRepository, ManagerUserRepository>();

            return services;
        }
    }
}
