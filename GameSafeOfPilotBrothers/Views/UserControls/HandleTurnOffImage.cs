using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    internal class HandleTurnOffImage:HandleImage
    {
        public HandleTurnOffImage()
        {
            Source = new BitmapImage(new Uri("../../Data/Img/HandleTurnOff.png", UriKind.Relative));
        }
    }
}
