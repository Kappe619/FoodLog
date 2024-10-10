using FoodLog.Shared.Interfaces;
using FoodLog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;

namespace FoodLog.WPF.Services
{
    using Microsoft.Win32;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using FoodLog.Shared.Models; // Adjust namespace if needed

    public class WpfFileService : IFileService
    {
        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            try
            {
                // Create an OpenFileDialog to let the user select a file
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Please select a JSON file",
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    // Get the file path from the dialog
                    string filePath = openFileDialog.FileName;

                    // Read and deserialize the JSON data
                    using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    using var reader = new StreamReader(stream);
                    var jsonData = await reader.ReadToEndAsync();

                    var foodItems = JsonSerializer.Deserialize<List<FoodItem>>(jsonData);

                    // Return the list or an empty list if deserialization failed
                    return foodItems ?? new List<FoodItem>();
                }
                else
                {
                    // User canceled the file selection
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

        public Task<string> LoadAndMergeDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> ReadFileAsync()
        {
            throw new NotImplementedException();
        }
   
   

        public async Task<string> ReadFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }

    }
}
