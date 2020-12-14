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
                .AddSingleton<IWelcomeView, WelcomeView>()
                .AddSingleton<ISearchImageView, SearchImageView>()
                .AddSingleton<IUploadImageView, UploadImageView>()
                .AddSingleton<IImageFilterView, ImageFiltersView>()
                .AddSingleton<IImageHandler, ImageHandler>()
                .AddSingleton<ISingleFilterView, SingleFilterView>()
                .AddSingleton<IGaussianFilter, GaussianFilter>()
                .AddSingleton<IMedianFilter, MedianFilter>()
                .BuildServiceProvider();
        }
    }
}