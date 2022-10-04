using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    internal class HandleTurnOnImage:HandleImage
    {
        public HandleTurnOnImage()
        {
            Source = new ImageSourceConverter().ConvertFrom("../../../Data/Img/HandleTurnOn3.png") as ImageSource;
        }
    }
}
