using Catel;
using Catel.MVVM;
using Catel.Windows.Input;
using System;
using Windows.System;

namespace CatelAppWideCommands.Uwp
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ICommandManager _commandManager;

        public DateTime UpdatedTimestamp { get; set; }

        public Command RefreshCommand { get; set; }

        public MainViewModel(ICommandManager commandManager)
        {
            Argument.IsNotNull(() => commandManager);

            _commandManager = commandManager;

            _commandManager.CreateCommand("Refresh", new InputGesture(VirtualKey.F5));
            RefreshCommand = new Command(() => { UpdatedTimestamp = DateTime.Now; });
            _commandManager.RegisterCommand("Refresh", RefreshCommand, this);
        }
    }
}
