using academymanagement.Domain.Interfaces.Repositories;
using academymanagement.Infra.Data;
using academymanagement.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace academymanagement.Infra
{
    public static class Startup
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            string _connectionString = configuration.GetConnectionString("MySqlConntectionString");

            services.AddDbContext<DataContext>(options => options.UseMySql(
                _connectionString
                , ServerVersion.AutoDetect(_connectionString)
                , o => o.SchemaBehavior(MySqlSchemaBehavior.Ignore)));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserGroupRepository), typeof(UserGroupRepository));
        }
    }
}
