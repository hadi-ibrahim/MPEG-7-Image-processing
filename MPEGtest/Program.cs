using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;


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
            MainAsync();
            Application.Run(new Form0());
        }

        static async Task MainAsync()
        {
            // Create service collection
            ServiceCollection serviceCollection = new ServiceCollection();
            Startup.ConfigureServices(serviceCollection);
        }
    }
}