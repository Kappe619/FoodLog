using FoodLog.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodLog.Shared.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadFileAsync();

        Task<string> LoadAndMergeDataAsync();

        Task<List<FoodItem>> GetFoodItemsAsync();
    }

}
