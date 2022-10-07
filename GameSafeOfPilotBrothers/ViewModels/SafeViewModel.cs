using GameSafeOfPilotBrothers.Models;
using GameSafeOfPilotBrothers.ViewModels.Base;
using System;
using System.Windows.Input;
using GameSafeOfPilotBrothers.Infrastructure.Commands;

namespace GameSafeOfPilotBrothers.ViewModels
{
    internal class SafeViewModel : ViewModel
    {
        public Safe Safe { get; private set; }
        private ISettings _settings;

        #region Свойства

        #region HandleLock
        private bool[,] _handleLock = null!;
        public bool[,] HandleLock
        {
            get { return _handleLock; }
            set => Set(ref _handleLock, value);
        }


        #endregion

        #region LockOfSafeCondition

        private LockConditionEnum _lockOfSafeCondition;

        public LockConditionEnum LockOfSafeCondition
        {
            get => _lockOfSafeCondition;
            set => Set(ref _lockOfSafeCondition, value);
        }

        #endregion

        #endregion
        

        #region Команды

        #region Команда TurnHandleCommand 
        public ICommand TurnHandleCommand { get; }

        private bool CanTurnHandleCommandExecute(object p)
        {
            PositionInLock position = (PositionInLock)p;
            if (position.X <= Safe.NumberHandlesInRow && position.Y <= Safe.NumberHandlesInRow &&
                Safe.LockCondition == LockConditionEnum.Close)
            {
                return true;
            }
            return false;
        }

        private void OnTurnHandleCommandExecuted(object p)
        {
           Safe.TurnHandle((PositionInLock)p);
        }

        #endregion
        #region Команда CreateNewSafe 
        public ICommand CreateNewSafe { get; }

        private bool CanCreateNewSafeExecute(object p) => true;

        private void OnCreateNewSafeExecuted(object p)
        {
            Safe = new Safe(new RandomLockOfSafeFactory(_settings.NumberHandlesInRow));
            Safe.LockChanged += LockOfSafeChanged;

            HandleLock = Safe.HandleLock;
            LockOfSafeCondition = Safe.LockCondition;
        }

        #endregion

        #endregion
        public SafeViewModel()
        {
            _settings = Settings.GetSettings();

            Safe = new Safe(new RandomLockOfSafeFactory(_settings.NumberHandlesInRow));
            Safe.LockChanged += LockOfSafeChanged;

            HandleLock = Safe.HandleLock;
            LockOfSafeCondition = Safe.LockCondition;

            TurnHandleCommand = new LambdaCommand(OnTurnHandleCommandExecuted, CanTurnHandleCommandExecute);
            CreateNewSafe = new LambdaCommand(OnCreateNewSafeExecuted, CanCreateNewSafeExecute);
        }

        private void LockOfSafeChanged(object? safe, EventArgs args)
        {
            HandleLock = Safe.HandleLock;
            LockOfSafeCondition = Safe.LockCondition;
        }
    }
}
