using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    internal class HandleTurnOnImage:HandleImage
    {
        public HandleTurnOnImage()
        {
            Source = new BitmapImage(new Uri("../../Data/Img/HandleTurnOn.png", UriKind.Relative));
        }
    }
}
