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

namespace FoodLog.Shared.Services
{
    public class FileService
    {
        private readonly IFileService _fileService;
        public FileService(IFileService fileService) {

            _fileService = fileService;
        
        }
        private ObservableCollection<FoodItem> _foodItems = new ObservableCollection<FoodItem>();

        public ObservableCollection<FoodItem> FoodItems
        {
            get => _foodItems;
            set
            {
                if (_foodItems != value)
                {
                    _foodItems = value;
                    // Notify UI (if using INotifyPropertyChanged)
                    OnPropertyChanged(nameof(FoodItems));
                }
            }
        }

        /// <summary>
        /// Loads data from two JSON files, merges the content, and updates the observable collection.
        /// </summary>
        /// <param name="foodDataPath">
        /// The file path of the main JSON file (e.g., "foodData.json") to load.
        /// Defaults to "Resources/Raw/foodData.json" if not provided.
        /// </param>
        /// <param name="newDataPath">
        /// The file path of the additional JSON file (e.g., "NewData.json") to load and merge.
        /// Defaults to "Resources/Raw/NewData.json" if not provided.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. Upon completion, the merged data
        /// is available in the <see cref="FoodItems"/> observable collection.
        /// </returns>
        /// <remarks>
        /// The method asynchronously loads the specified JSON files, deserializes them into lists of <see cref="FoodItem"/> objects,
        /// merges the content (adding new items from <paramref name="newDataPath"/> into the main list from <paramref name="foodDataPath"/>),
        /// and updates the <see cref="FoodItems"/> collection. Duplicate items are avoided based on the food item's name.
        /// </remarks>
        public async Task LoadAndMergeDataAsync(string foodDataPath = "Resources/Raw/FoodData.json", string newDataPath = "Resources/Raw/NewData.json")
        {
            // Load foodData.json
            var foodData = await LoadDataFromFileAsync(foodDataPath);

            // Load NewData.json
            var newData = await LoadDataFromFileAsync(newDataPath);

            // Merge newData into foodData
            foreach (var item in newData)
            {
                if (!foodData.Any(f => f.Name == item.Name)) // Prevent duplicates (if Name is unique)
                {
                    foodData.Add(item);
                }
            }

            // Update the ObservableCollection with the merged data
            FoodItems = new ObservableCollection<FoodItem>(foodData);
        }

        // Helper method to load and deserialize data from a JSON file, with optional filepath parameter
        private async Task<List<FoodItem>> LoadDataFromFileAsync(string filePath)
        {
            //using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
            //using var reader = new StreamReader(stream);
            //var json = await reader.ReadToEndAsync();

            //return JsonSerializer.Deserialize<List<FoodItem>>(json);

            var json = await _fileService.ReadFileAsync();
            return JsonSerializer.Deserialize<List<FoodItem>>(json);

        }

        // INotifyPropertyChanged implementation (if needed)
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
