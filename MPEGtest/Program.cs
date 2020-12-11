using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MPEGtest.Common.Helpers;
using MPEGtest.ImageFilters;
using MPEGtest.Views;
using MPEGtest.Views.ViewInterfaces;


namespace MPEGtest
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Startup.ConfigureServices();
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddTransient<IWelcomeView, WelcomeView>()
                .AddTransient<ISearchImageView, SearchImageView>()
                .AddTransient<IUploadImageView, UploadImageView>()
                .AddSingleton<IImageHandler, ImageHandler>()
                .BuildServiceProvider();
            RoutingHelper.ServiceProvider = serviceProvider;
            var welcomeView = serviceProvider.GetService<IWelcomeView>();
            
            Application.Run((Form) welcomeView);
            
        }

        
    }
}