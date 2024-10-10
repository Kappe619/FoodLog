using CommunityToolkit.Mvvm.Input;
using FoodLog.Shared.Interfaces;
using FoodLog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodLog.Shared.ViewModels
{
    public class TableViewModel
    {

        // Beispiel-Datenquelle für die Tabelle
        IFileService _fileService;
        private ObservableCollection<FoodItem> _tableItems;
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

        public TableViewModel(IFileService service)
        {
            TableItems = new ObservableCollection<FoodItem>();

            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem);
            _fileService = service;
        }

        private void AddItem()
        {
            // Logic to add an item to TableItems
        }
        private void RemoveItem()
        {
            // Logic to remove an item from TableItems
        }

        // Event, um die View über Änderungen zu informieren
        public event PropertyChangedEventHandler PropertyChanged;

        // Methode, um das PropertyChanged-Event auszulösen
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private async void LoadData()
        //{
        //    await LoadDataAsync();
        //}

        ///// <summary>
        ///// Asynchronously loads data from the "FoodData.json" file located in the app's Resources/Raw folder,
        ///// deserializes it into a list of <see cref="FoodItem"/> objects, and adds them to the <see cref="FoodItems"/> collection.
        ///// </summary>
        ///// <returns>
        ///// A task representing the asynchronous operation of loading and deserializing the JSON data.
        ///// </returns>
        ///// <remarks>
        ///// This method opens the packaged "FoodData.json" file, reads its content, and deserializes the JSON data
        ///// into a list of <see cref="FoodItem"/> objects. The deserialized objects are then added to the
        ///// <see cref="FoodItems"/> collection. If needed, existing items can be cleared before adding new ones by uncommenting
        ///// the <c>FoodItems.Clear()</c> line.
        ///// </remarks>       
        //public async Task LoadDataAsync()
        //{
        //    // Get the stream from the packaged file in Resources/Raw
        //    using var stream = await FileSystem.OpenAppPackageFileAsync("FoodData.json");

        //    // Read the content of the stream
        //    using var reader = new StreamReader(stream);
        //    string json = await reader.ReadToEndAsync();

        //    // Deserialize the JSON into a list of FoodItem objects
        //    var items = JsonSerializer.Deserialize<List<FoodItem>>(json);

        //    // Add the deserialized items to the FoodItems collection
        //    if (items != null)
        //    {
        //        // FoodItems.Clear();  // Clear the existing items (if necessary)
        //        foreach (var item in items)
        //        {
        //            FoodItems.Add(item);
        //        }
        //    }
        //}

        //public ICommand LoadDataCommand { get; }

    }
}
