using System.IO;

namespace ScoreTracker.Utilities
{
    public class FileOperations:IFileOperations
    {
        private IAppSettings _appSettings;

        public FileOperations(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public string ReadDataFromFileDatabase()
        {
            var filePath = _appSettings.FileDatabasePath;
            return File.ReadAllText(filePath);
        }
        public bool WriteDataToFileDatabase(string JsonToUpdate)
        {
            File.WriteAllText(_appSettings.FileDatabasePath, JsonToUpdate);
            return true;
        }
    }
}
