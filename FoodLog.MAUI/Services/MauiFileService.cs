﻿using FoodLog.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            using var stream = await FileSystem.OpenAppPackageFileAsync(filePath);
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}
