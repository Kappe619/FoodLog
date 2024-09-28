using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;
using FoodLog.ViewModels;
using FoodLog.Models;
using FoodLog.Resources.Localization;

namespace FoodLog.ViewModels
{
    public class TableViewModel : INotifyPropertyChanged
    {
        // Beispiel-Datenquelle für die Tabelle
        private ObservableCollection<FoodItem> _foodItems;
        public ObservableCollection<FoodItem> FoodItems
        {
            get => _foodItems;
            set
            {
                if (_foodItems != value)
                {
                    _foodItems = value;
                    OnPropertyChanged(nameof(FoodItems));
                }
            }
        }

        public TableViewModel()
        {
            FoodItems = new ObservableCollection<FoodItem>
            {

            };
            LoadDataCommand = new Command(async () => await LoadDataAsync());

        }

        // Event, um die View über Änderungen zu informieren
        public event PropertyChangedEventHandler PropertyChanged;

        // Methode, um das PropertyChanged-Event auszulösen
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void LoadData()
        {
            await LoadDataAsync();
        }

        /// <summary>
        /// Asynchronously loads data from the "FoodData.json" file located in the app's Resources/Raw folder,
        /// deserializes it into a list of <see cref="FoodItem"/> objects, and adds them to the <see cref="FoodItems"/> collection.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation of loading and deserializing the JSON data.
        /// </returns>
        /// <remarks>
        /// This method opens the packaged "FoodData.json" file, reads its content, and deserializes the JSON data
        /// into a list of <see cref="FoodItem"/> objects. The deserialized objects are then added to the
        /// <see cref="FoodItems"/> collection. If needed, existing items can be cleared before adding new ones by uncommenting
        /// the <c>FoodItems.Clear()</c> line.
        /// </remarks>
        public async Task LoadDataAsync()
        {
            // Get the stream from the packaged file in Resources/Raw
            using var stream = await FileSystem.OpenAppPackageFileAsync("FoodData.json");

            // Read the content of the stream
            using var reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync();

            // Deserialize the JSON into a list of FoodItem objects
            var items = JsonSerializer.Deserialize<List<FoodItem>>(json);

            // Add the deserialized items to the FoodItems collection
            if (items != null)
            {
                // FoodItems.Clear();  // Clear the existing items (if necessary)
                foreach (var item in items)
                {
                    FoodItems.Add(item);
                }
            }
        }

        public ICommand LoadDataCommand { get; }


    }


}