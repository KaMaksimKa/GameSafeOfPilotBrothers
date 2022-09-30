using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    internal interface ISettings
    {
        public int NumberHandlesInRow { get; set; }
        public void SaveChanges();
    }
}
