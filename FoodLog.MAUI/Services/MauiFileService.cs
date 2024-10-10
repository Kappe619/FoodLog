using System.IO;
using System.Threading.Tasks;
using FoodLog.Shared;
using FoodLog.Shared.Interfaces;
public class MauiFileService : IFileService
{
    public async Task<string> ReadFileAsync(string filePath)
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}
