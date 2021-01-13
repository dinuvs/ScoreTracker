using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker.Utilities
{
    public interface IFileOperations
    {
        string ReadDataFromFileDatabase();
        bool WriteDataToFileDatabase(string JsonToUpdate);
    }
}
