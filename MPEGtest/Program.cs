using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MPEGtest.Common;
using MPEGtest.Common.Helpers;
using MPEGtest.ImageFilters;
using MPEGtest.ImageFilters.Filters;
using MPEGtest.ImageFilters.Filters.Interfaces;
using MPEGtest.Views;
using MPEGtest.Views.SingleFiltersView;
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
            // Application.Run(new UploadImageView());
            var serviceProvider = ConfigureServices();
            RoutingHelper.ServiceProvider = serviceProvider;
            Application.Run(serviceProvider.GetService<IWelcomeView>() as Form);
        }


        static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddLogging()
                .AddTransient<IWelcomeView, WelcomeView>()
                .AddTransient<ISearchImageView, SearchImageView>()
                .AddTransient<IUploadImageView, UploadImageView>()
                .AddTransient<IImageFilterView, ImageFiltersView>()
                .AddSingleton<IImageHandler, ImageHandler>()
                .AddTransient<ISingleFilterView, SingleFilterView>()
                .AddTransient<IGaussianFilter, GaussianFilter>()
                .AddTransient<IMedianFilter, MedianFilter>()
                .BuildServiceProvider();
        }
    }
}