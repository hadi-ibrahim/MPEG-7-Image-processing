using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MPEGtest.ImageFilters;


namespace MPEGtest
{
    public static class Startup
    {
        public static Task ConfigureServices()
        {
            // Create service collection
            // ServiceCollection serviceCollection = new ServiceCollection();
            using IHost host = CreateHostBuilder().Build();

            // ConfigureServices(host.Services);
            // Startup.ConfigureServices(serviceCollection);
            return host.RunAsync();
        }
        
        static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();

                    services.AddSingleton<IImageHandler, ImageHandler>()
                        .AddSingleton<IConfiguration>(configuration);
                });

        public static void ConfigureServices(IServiceProvider services)
        {

            // using IServiceScope serviceScope = services.CreateScope();
            // IServiceProvider provider = serviceScope.ServiceProvider;
            //
            // IConfigurationRoot configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            //     .AddJsonFile("appsettings.json", false)
            //     .Build();

            // // Add access to generic IConfigurationRoot
            // serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            // serviceCollection.AddSingleton<IImageHandler>(new ImageHandler());
        }
    }
}