using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameSafeOfPilotBrothers.Models;

namespace GameSafeOfPilotBrothers.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для LockUserControl.xaml
    /// </summary>
    public partial class LockUserControl:UserControl
    {
        #region Свойство HandleLock

        public bool[,] HandleLock
        {
            get => (bool[,])GetValue(HandleLockProperty);
            set => SetValue(HandleLockProperty, value);
        }

        public static readonly DependencyProperty HandleLockProperty =
            DependencyProperty.Register("HandleLock", typeof(bool[,]),
                typeof(LockUserControl), new PropertyMetadata(SetHandleLock));

        private static void SetHandleLock(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is null)
            {
                return;
            }
            LockUserControl control = (LockUserControl)d;
            var handleLock = (bool[,]) e.NewValue;
            control.Lock.Columns = handleLock.GetLength(0);
            control.Lock.Rows = handleLock.GetLength(1);
            control.Lock.Children.Clear();
            for (int i = 0; i < handleLock.GetLength(0); i++)
            {
                for (int j = 0; j < handleLock.GetLength(1); j++)
                {
                    HandleImage handle;
                    if (handleLock[i,j])
                    {
                         handle = new HandleTurnOnImage() { PositionInLock = new PositionInLock(i, j) };
                    }
                    else
                    {
                         handle = new HandleTurnOffImage(){PositionInLock = new PositionInLock(i,j)};
                    }
                    handle.MouseLeftButtonDown += control.HandleOnMouseLeftButtonDown;
                    control.Lock.Children.Add(handle);
                }
            }
            
        }

        
        #endregion

        private void HandleOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HandleImage handleImage = (HandleImage) sender;
            if (TurnHandleCommand.CanExecute(handleImage.PositionInLock))
            {
                TurnHandleCommand?.Execute(handleImage.PositionInLock);
            }
        }

        #region Свойство TurnHandleCommand

        public ICommand TurnHandleCommand
        {
            get => (ICommand)GetValue(TurnHandleCommandProperty);
            set => SetValue(TurnHandleCommandProperty, value);
        }

        public static readonly DependencyProperty TurnHandleCommandProperty =
            DependencyProperty.Register("TurnHandleCommand", typeof(ICommand),
                typeof(LockUserControl));



        #endregion
        public LockUserControl()
        {
            InitializeComponent();
        }
    }
}
