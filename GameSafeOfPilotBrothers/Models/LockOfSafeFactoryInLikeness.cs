using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    public class LockOfSafeFactoryInLikeness:ILockOfSafeFactory
    {
        public bool[,] LockOfSafe { get; }
        public LockOfSafeFactoryInLikeness(bool[,] lockOfSafe)
        {
            LockOfSafe = lockOfSafe;
        }

        public bool[,] GetLockOfSafe() => LockOfSafe;
    }
}
