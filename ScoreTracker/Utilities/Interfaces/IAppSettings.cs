using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker.Utilities
{
    public interface IAppSettings
    {
       // string GetFileDatabasePath();
        string FileDatabasePath { get; }
    }
}
