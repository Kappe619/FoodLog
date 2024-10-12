using FoodLog.MAUI.Services;
using FoodLog.Shared.Interfaces;
using DotNetEnv;
using Syncfusion.Licensing;
using FoodLog.Shared.Services;

namespace FoodLog.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Load environment variables from .env file
            DotNetEnv.Env.Load(FilePathService.EnvFilePath());

            // Retrieve and register the Syncfusion license key
            var licenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            if (!string.IsNullOrEmpty(licenseKey))
            {
                SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            }

            MainPage = new AppShell();
            //builder.Services.AddSingleton<IFileService, MauiFileService>();

        }
    }
}
