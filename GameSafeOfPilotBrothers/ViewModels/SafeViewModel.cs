﻿using GameSafeOfPilotBrothers.Models;
using GameSafeOfPilotBrothers.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool[][] HandleLock
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
        private bool[][] _handleLock;

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

        #endregion
        public SafeViewModel()
        {
            _settings = Settings.GetSettings();
            Safe = new Safe(_settings.NumberHandlesInRow);
            Safe.LockChanged += LockOfSafeChanged;
            HandleLock = Safe.HandleLock;
            LockOfSafeCondition = Safe.LockCondition;
            TurnHandleCommand = new LambdaCommand(OnTurnHandleCommandExecuted, CanTurnHandleCommandExecute);
        }

        private void LockOfSafeChanged(object? safe, EventArgs args)
        {
            HandleLock = Safe.HandleLock;
            LockOfSafeCondition = Safe.LockCondition;
        }
    }
}
