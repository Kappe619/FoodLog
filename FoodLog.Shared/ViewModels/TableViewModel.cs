using CommunityToolkit.Mvvm.Input;
using FoodLog.Shared.Interfaces;
using FoodLog.Shared.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FoodLog.Shared.ViewModels
{
    public class TableViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<FoodItem> TableItems
        {
            get => _tableItems;
            set
            {
                if (_tableItems != value)
                {
                    _tableItems = value;
                    OnPropertyChanged(nameof(TableItems));
                }
            }
        }

        public ICommand AddItemCommand { get; }
        public ICommand RemoveItemCommand { get; }

        private readonly IFileService _fileService;
        private ObservableCollection<FoodItem> _tableItems;

        public TableViewModel(IFileService service)
        {
            TableItems = new ObservableCollection<FoodItem>();

            AddItemCommand = new RelayCommand(AddItems);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            _fileService = service;
        }

        private async void AddItems()
        {
            // Call the async file service method
            List<FoodItem> foodItems = await _fileService.GetFoodItemsAsync();

            // Add items to the observable collection
            foreach (var item in foodItems)
            {
                TableItems.Add(item);
            }
        }
        private void RemoveItem()
        {
            // Logic to remove an item from TableItems
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
