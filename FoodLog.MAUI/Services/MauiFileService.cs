using FoodLog.Shared.Interfaces;
using FoodLog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodLog.MAUI.Services
{
    public class MauiFileService : IFileService
    {
        public Task<string> LoadAndMergeDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReadFileAsync(string filePath)
        {

            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Select json file"
            });

            if (result != null)
            {
                // Get the full file path
                string path = result.FullPath;

                // Display or process the file (e.g., read contents)
                var fileService = new MauiFileService();
                var foodItems = await fileService.GetFoodItemsAsync(path);

                // You can now use the `foodItems` list in your page or ViewModel
                // Example: Display in a ListView, or add to your ObservableCollection
            }

            using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);  //FIX find best way for correct filepath
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync(string filePath)
        {
            // Read the JSON data from the file
            var jsonData = await ReadFileAsync(filePath);

            // Deserialize the JSON data into a List of FoodItem objects
            var foodItems = JsonSerializer.Deserialize<List<FoodItem>>(jsonData);

            // Return the list, or an empty list if deserialization returns null
            return foodItems ?? new List<FoodItem>();
        }


        public async void OnSelectFileButtonClicked()
        {
            await LoadFileAsync();
        }
        public async Task LoadFileAsync()
        {
            try
            {
                // Prompt the user to select a file
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Please select a JSON file"
                });

                if (result != null)
                {
                    // Get the full file path
                    string filePath = result.FullPath;

                    // Display or process the file (e.g., read contents)
                    var fileService = new MauiFileService();
                    var foodItems = await fileService.GetFoodItemsAsync(filePath);

                    // You can now use the `foodItems` list in your page or ViewModel
                    // Example: Display in a ListView, or add to your ObservableCollection
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., user canceled the file picker or permission error)
                Console.WriteLine($"File selection error: {ex.Message}");
            }
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            try
            {
                // Prompt the user to select a JSON file
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Please select a JSON file"
                });

                if (result != null)
                {
                    // Read the file contents as a string
                    using var stream = await result.OpenReadAsync();
                    using var reader = new StreamReader(stream);
                    var jsonData = await reader.ReadToEndAsync();


                    // Deserialize the JSON data into a List of FoodItem objects
                    var foodItems = JsonSerializer.Deserialize<List<FoodItem>>(jsonData);

                    // Return the list or an empty list if deserialization failed
                    return foodItems ?? new List<FoodItem>();
                }
                else
                {
                    // User cancelled the file selection
                    return new List<FoodItem>();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., file not found, JSON parse error)
                Console.WriteLine($"Error loading food items: {ex.Message}");
                return new List<FoodItem>(); // Return an empty list on error
            }
        }

        public Task<string> ReadFileAsync()
        {
            throw new NotImplementedException();
        }
    }
}
