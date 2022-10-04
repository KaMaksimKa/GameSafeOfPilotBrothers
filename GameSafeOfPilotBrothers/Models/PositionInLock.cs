using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    internal struct PositionInLock
    {
        public int X;
        public int Y;

        public PositionInLock(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
