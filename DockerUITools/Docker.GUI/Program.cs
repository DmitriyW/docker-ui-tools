using Docker.Abstractions.Services;
using Docker.GUI.Pages;
using Docker.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Docker.GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureServices();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IVolumeService, VolumeService>();
            services.AddScoped<ICommandRunner, CommandRunner>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T? GetService<T>() where T : class
        {
            return (T?)ServiceProvider.GetService(typeof(T));
        }
    }
}