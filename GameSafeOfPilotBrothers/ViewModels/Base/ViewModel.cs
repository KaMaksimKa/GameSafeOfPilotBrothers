using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GameSafeOfPilotBrothers.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
