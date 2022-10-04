using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    internal class HandleTurnOffImage:HandleImage
    {
        public HandleTurnOffImage()
        {
            Source = new ImageSourceConverter().ConvertFrom("../../../Data/Img/HandleTurnOff.png") as ImageSource;
        }
    }
}
