using FoodLog.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLog.WPF.Services
{
    public class WpfFileService : IFileService
    {
        public Task<string> LoadAndMergeDataAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> ReadFileAsync(string filePath)
        {
            return await File.ReadAllTextAsync(filePath);
        }
    }
}
