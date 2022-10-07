using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    internal class RandomLockOfSafeFactory : ILockOfSafeFactory
    {
        public int NumberHandlesInRow { get; }
        public RandomLockOfSafeFactory(int numberHandlesInRow)
        {
            NumberHandlesInRow = numberHandlesInRow;
        }
        public bool[,] GetLockOfSafe()
        {
            var handleLock = new bool[NumberHandlesInRow, NumberHandlesInRow];

            Random random = new Random();
            int countTurn = random.Next(100, 1000);
            bool startHandlesPosition = random.Next(2) == 1;
            for (int i = 0; i < NumberHandlesInRow; i++)
            {
                for (int j = 0; j < NumberHandlesInRow; j++)
                {
                    handleLock[i, j] = startHandlesPosition;
                }
            }
            Safe safe = new Safe(new LockOfSafeFactoryInLikeness(handleLock));
            while (safe.LockCondition == LockConditionEnum.Open)
            {
                for (int i = 0; i < countTurn; i++)
                {
                    safe.TurnHandle(new PositionInLock(random.Next(NumberHandlesInRow), random.Next(NumberHandlesInRow)));
                }
            }
            return safe.HandleLock;
        }
    }
}
