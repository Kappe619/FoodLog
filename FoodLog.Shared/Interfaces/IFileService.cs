using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLog.Shared.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadFileAsync(string filePath);

        Task<string> LoadAndMergeDataAsync();
    }

}
