using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

namespace academymanagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IConfigurationRoot configuration = GetConfiguration();

            ConfiguraLog(configuration);

            try
            {
                Log.Information("Initializing application.");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application run error.");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static void ConfiguraLog(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
                .Build();
            return configuration;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
