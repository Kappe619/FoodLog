using Syncfusion.Licensing;
using System.Configuration;
using System.Data;
using System.Windows;
using DotNetEnv;
using System.IO;
using FoodLog.Shared.Services;

namespace FoodLog.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DotNetEnv.Env.Load(FilePathService.EnvFilePath());

            // Retrieve and register the Syncfusion license key
            var licenseKey = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            if (!string.IsNullOrEmpty(licenseKey))
            {
                SyncfusionLicenseProvider.RegisterLicense(licenseKey);
            }
            else
            {
                MessageBox.Show("Syncfusion license key not found.");
            }
        }


}

}
