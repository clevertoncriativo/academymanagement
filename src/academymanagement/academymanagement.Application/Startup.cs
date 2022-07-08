using academymanagement.Application.Apps;
using academymanagement.Application.Interfaces;
using academymanagement.Domain.Entities;
using academymanagement.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace academymanagement.Application
{
    public static class Startup
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region Validators

            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<UserGroup>, UserGroupValidator>();

            #endregion

            #region Apps

            services.AddScoped<IUserApp, UserApp>();
            services.AddScoped<IUserGroupApp, UserGroupApp>();

            #endregion
        }
    }
}
