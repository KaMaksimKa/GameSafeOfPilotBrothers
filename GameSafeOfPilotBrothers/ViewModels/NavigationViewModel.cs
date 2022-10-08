using GameSafeOfPilotBrothers.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GameSafeOfPilotBrothers.Infrastructure.Commands;
using GameSafeOfPilotBrothers.Models;
using GameSafeOfPilotBrothers.ViewModels;

namespace GameSafeOfPilotBrothers.ViewModels
{
    internal class NavigationViewModel : ViewModel
    {
        #region Свойства

        #region SelectedViewModel
        private ViewModel _selectedViewModel;
        public ViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);

        }

        #endregion


        #endregion

        #region Команды

        #region Команда SelectSettingsCommand 
        public ICommand SelectSettingsCommand { get; }

        private bool CanSelectSettingsCommandExecute(object p) => true;

        private void OnSelectSettingsCommandExecuted(object p)
        {
            SelectedViewModel = new SettingsViewModel();
        }

        #endregion

        #region Команда SelectSafeCommand 
        public ICommand SelectSafeCommand { get; }

        private bool CanSelectSafeCommandExecute(object p) => true;

        private void OnSelectSafeCommandExecuted(object p)
        {
            SelectedViewModel = new SafeViewModel(Settings.GetSettings());
        }

        #endregion

        #endregion

        public NavigationViewModel()
        {
            SelectSettingsCommand = new LambdaCommand(OnSelectSettingsCommandExecuted, CanSelectSettingsCommandExecute);
            SelectSafeCommand = new LambdaCommand(OnSelectSafeCommandExecuted, CanSelectSafeCommandExecute);
            
            SelectedViewModel = new SafeViewModel(Settings.GetSettings());
        }
    }
}
