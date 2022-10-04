using GameSafeOfPilotBrothers.Models;
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
    internal class SettingsViewModel : ViewModel
    {
        #region Свойства

        #region NumberHandlesInRow
        private string _numberHandlesInRow;
        public string NumberHandlesInRow
        {
            get => _numberHandlesInRow;
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 || value == "")
                {
                    Set(ref _numberHandlesInRow, value);
                }
                else
                {
                    Set(ref _numberHandlesInRow, _numberHandlesInRow);
                }

            }
        }

        #endregion


        #endregion
        #region Команды

        #region Команда ChangeNumberHandlesInRowCommand 
        public ICommand ChangeNumberHandlesInRowCommand { get; }

        private bool CanChangeNumberHandlesInRowCommandExecute(object p) => int.TryParse(NumberHandlesInRow, out int result) && result > 0;

        private void OnChangeNumberHandlesInRowCommandExecuted(object p)
        {
            Settings.NumberHandlesInRow = int.Parse(NumberHandlesInRow);
            Settings.SaveChanges();
        }

        #endregion


        #endregion

        public ISettings Settings { get; set; }
        public SettingsViewModel()
        {
            ChangeNumberHandlesInRowCommand = new LambdaCommand(OnChangeNumberHandlesInRowCommandExecuted,
                CanChangeNumberHandlesInRowCommandExecute);
            Settings = Models.Settings.GetSettings();
            NumberHandlesInRow = Settings.NumberHandlesInRow.ToString();
        }
    }
}
