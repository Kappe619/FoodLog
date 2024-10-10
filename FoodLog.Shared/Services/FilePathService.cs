namespace FoodLog.Shared.Services
{
    /// <summary>
    /// Provides utility methods to retrieve file paths within the solution directory.
    /// </summary>
    public static class FilePathService
    {
        /// <summary>
        /// Traverses the directory tree upwards from the current execution directory 
        /// to locate the solution root directory containing the specified solution file.
        /// </summary>
        /// <returns>
        /// The full path to the solution root directory containing the solution file (e.g., "FoodLog.sln").
        /// </returns>
        /// <exception cref="DirectoryNotFoundException">
        /// Thrown if the solution root directory cannot be found.
        /// </exception>
        public static string GetSolutionRootDirectory()
        {
            // Start from the current directory
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Traverse up the directory tree
            while (currentDirectory != null && !File.Exists(Path.Combine(currentDirectory, "FoodLog.sln")))
            {
                currentDirectory = Directory.GetParent(currentDirectory)?.FullName;
            }

            if (currentDirectory == null)
            {
                throw new DirectoryNotFoundException("Solution root directory not found.");
            }

            return currentDirectory;
        }

        /// <summary>
        /// Retrieves the full path to the ".env" file located in the solution root directory.
        /// </summary>
        /// <returns>
        /// The full file path to the ".env" file.
        /// </returns>
        public static string EnvFilePath()
        {
            return Path.Combine(GetSolutionRootDirectory(), ".env");
        }
    }
}
