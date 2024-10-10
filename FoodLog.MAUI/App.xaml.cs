using FoodLog.MAUI.Services;
using FoodLog.Shared.Interfaces;

namespace FoodLog.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //builder.Services.AddSingleton<IFileService, MauiFileService>();

        }
    }
}
