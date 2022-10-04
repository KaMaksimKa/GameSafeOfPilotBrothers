using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameSafeOfPilotBrothers.Models
{
    internal class Safe:ICloneable
    {
        public event EventHandler<EventArgs> LockChanged;
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
                UpdateLockCondition();
            }
        }

        private void UpdateLockCondition()
        {
            if (HandleLock.All(a => a.All(b => b)) || HandleLock.All(a => a.All(b => !b)))
            {
                LockCondition = LockConditionEnum.Open;
            }
            else
            {
                LockCondition = LockConditionEnum.Close;
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
            int countTurn = random.Next(100, 1000);
            bool startPosition = random.Next(2) == 1;
            for (int i = 0; i < numberHandlesInRow; i++)
            {
                handleLock[i] = Enumerable.Range(0, numberHandlesInRow).Select(a => startPosition).ToArray();
            }
            Safe safe = new Safe(handleLock);
            while (safe.LockCondition==LockConditionEnum.Open)
            {
                for (int i = 0; i < countTurn; i++)
                {
                    safe.TurnHandle(new PositionInLock(random.Next(numberHandlesInRow), random.Next(numberHandlesInRow)));
                }
            }
            

            return safe.HandleLock;
        }

        public void TurnHandle(PositionInLock positionInLock)
        {
            _handleLock[positionInLock.X][ positionInLock.Y] = !_handleLock[positionInLock.X][ positionInLock.Y];
            for (int i = 0; i < NumberHandlesInRow; i++)
            {
                if (i != positionInLock.X)
                {
                    _handleLock[i][positionInLock.Y] = !_handleLock[i][positionInLock.Y];
                }
                if (i != positionInLock.Y)
                {
                    _handleLock[positionInLock.X][i] = !_handleLock[positionInLock.X][i];
                }
            }

            UpdateLockCondition();
            LockChanged?.Invoke(this,EventArgs.Empty);
        }

        public object Clone()
        {
            var ar = new bool[NumberHandlesInRow][];
            for (int i = 0; i < NumberHandlesInRow; i++)
            {
                ar[i] = (bool[])_handleLock[i].Clone();
            }

            return new Safe(ar);
        }
    }
}
