using academymanagement.Domain.Interfaces.Services;
using academymanagement.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace academymanagement.Domain
{
    public static class Startup
    {
        public static void AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });

        }
    }
}
