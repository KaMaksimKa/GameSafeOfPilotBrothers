using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GameSafeOfPilotBrothers.Models;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    internal class HandleImage:Image
    {
        public PositionInLock PositionInLock { get; init; }
    }
}
