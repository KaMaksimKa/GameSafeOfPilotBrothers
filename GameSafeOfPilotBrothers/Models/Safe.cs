using System;
using System.Linq;


namespace GameSafeOfPilotBrothers.Models
{
    public class Safe
    {
        public event EventHandler<EventArgs>? LockChanged;
        private bool[,] _handleLock = null!;
        public bool[,] HandleLock
        {
            get => (bool[,])_handleLock.Clone();
            private init
            {
                if (value.Length == 0 && value.GetLength(0)!=value.GetLength(1))
                {
                    throw new ArgumentException("Размер handleLock должен быть NxN где N больше 0");
                }
                _handleLock = value;
                UpdateLockCondition();
            }
        }
        public int NumberHandlesInRow => _handleLock.GetLength(0);
        public LockConditionEnum LockCondition { get; private set; }
        public Safe(ILockOfSafeFactory lockOfSafeFactory)
        {
            HandleLock = lockOfSafeFactory.GetLockOfSafe();
        }
        private void UpdateLockCondition()
        {
            if (HandleLock.Cast<bool>().All(e=>e) || HandleLock.Cast<bool>().All(e => !e))
            {
                LockCondition = LockConditionEnum.Open;
            }
            else
            {
                LockCondition = LockConditionEnum.Close;
            }
        }
        public void TurnHandle(PositionInLock positionInLock)
        {
            _handleLock[positionInLock.X,positionInLock.Y] = !_handleLock[positionInLock.X, positionInLock.Y];
            for (int i = 0; i < NumberHandlesInRow; i++)
            {
                if (i != positionInLock.X)
                {
                    _handleLock[i,positionInLock.Y] = !_handleLock[i,positionInLock.Y];
                }
                if (i != positionInLock.Y)
                {
                    _handleLock[positionInLock.X,i] = !_handleLock[positionInLock.X,i];
                }
            }

            UpdateLockCondition();
            LockChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}
