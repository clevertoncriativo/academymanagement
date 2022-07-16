using academymanagement.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace academymanagement.Api.Configurations
{
    public static class DataBaseConfig
    {
        public static void UseDatabaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<DataContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}
