using GameSafeOfPilotBrothers.Models;
using GameSafeOfPilotBrothers.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.ViewModels
{
    internal class SafeViewModel : ViewModel
    {
        public Safe Safe { get; private set; }
        private ISettings _settings;
        public SafeViewModel()
        {
            _settings = Settings.GetSettings();
            Safe = new Safe(_settings.NumberHandlesInRow);
        }
    }
}
