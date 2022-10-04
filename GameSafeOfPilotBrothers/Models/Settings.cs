using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    [Serializable]
    public class Settings : ISettings
    {
        private static Settings? _settings;
        private Settings()
        {

        }

        public static Settings GetSettings()
        {
            if (_settings == null)
            {
                _settings = new Settings(){NumberHandlesInRow = UsersSettings.Default.NumberHandlesInRow };
            }
            return _settings;
        }

        public int NumberHandlesInRow { get; set; }
        public void SaveChanges()
        {
            UsersSettings.Default.NumberHandlesInRow = NumberHandlesInRow;
            UsersSettings.Default.Save();
        }
    }
}
