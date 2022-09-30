using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    internal class Safe
    {
        private bool[][] _handleLock = null!;

        public bool[][] HandleLock
        {
            get => (bool[][])_handleLock.Clone();
            set
            {
                if (value.Length == 0 && value.Any(a => a.Length != value.Length))
                {
                    throw new ArgumentException("Размер handleLock должен быть NxN где N больше 0");
                }
                _handleLock = value;
                /*if (HandleLock.)
                {
                    
                }*/
            }
        }

        private int _numberHandlesInRow;
        public int NumberHandlesInRow
        {
            get => _numberHandlesInRow;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("NumberHandlesInRow должен быть больше 0");
                }
                _numberHandlesInRow = value;

            }
        }
        public LockConditionEnum LockCondition { get; private set; }

        public Safe(bool[][] handleLock)
        {
            HandleLock = handleLock;
            NumberHandlesInRow = HandleLock.GetLength(0);
        }
        public Safe(int numberHandlesInRow)
        {
            NumberHandlesInRow = numberHandlesInRow;
            HandleLock = CreateHandleLock(NumberHandlesInRow);
        }

        private bool[][] CreateHandleLock(int numberHandlesInRow)
        {
            var handleLock = new bool[numberHandlesInRow][];

            Random random = new Random();
            for (int i = 0; i < numberHandlesInRow; i++)
            {
                handleLock[i] = new bool[numberHandlesInRow];
                for (int j = 0; j < numberHandlesInRow; j++)
                {
                    handleLock[i][j] = random.Next(2) == 1;
                }
            }
            return handleLock;
        }
    }
}
