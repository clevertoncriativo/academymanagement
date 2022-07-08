using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace academymanagement.Api.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string version = "v1";

        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version,
                    new OpenApiInfo
                    {
                        Title = "Sistema de Gestão para Academias",
                        Version = "v1",
                        Description = "API da aplicação gestão para academias.",
                        Contact = new OpenApiContact
                        {
                            Name = "Cléverton Silva",
                            Email = "clevertonti@gmail.com",
                            Url = new Uri("https://github.com/clevertoncriativo")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd")
                    });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Insira o token",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});

                //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //{
                //    new OpenApiSecurityScheme
                //    {
                //        Reference= new OpenApiReference
                //        {
                //            Type = ReferenceType.SecurityScheme,
                //            Id ="Bearer"
                //        }
                //    },
                //        Array.Empty<string>()
                //}
                //});

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                //xmlPath = Path.Combine(AppContext.BaseDirectory, "CL.Core.Shared.xml");
                //c.IncludeXmlComments(xmlPath);
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint($"./swagger/{version}/swagger.json", $"Gestão de Academia {version}");
            });
        }
    }
}
