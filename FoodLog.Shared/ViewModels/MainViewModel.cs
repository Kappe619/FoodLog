using FoodLog.Shared.Interfaces;
using FoodLog.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodLog.Shared.ViewModels
{
    internal class MainViewModel
    {
        public ICommand AddDataCommand { get; }
        private readonly IFileService service = null!;
        public MainViewModel()
        {
            //AddDataCommand = new ICommand(async () => await AddDataAsync());
            //service = new FileService();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public async void AddData()
        {
            await AddDataAsync();
        }

        public async Task AddDataAsync()
        {
            await service.LoadAndMergeDataAsync();
        }
    }
}
