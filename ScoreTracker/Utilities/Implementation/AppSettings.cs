using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreTracker.Utilities
{
    public class AppSettings: IAppSettings
    {
        private IConfiguration _config;

        public AppSettings(IConfiguration config)
        {
            _config = config;
        }

        public string  FileDatabasePath => (_config.GetValue<string>("FileDatabasePath"));

    }
}
