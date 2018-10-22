using System;
using System.Windows.Input;

namespace ViewModels.Commands
{
    public class DictationModeCmd : ICommand
    {
        public ViewModelBase ViewModel { get; set; }

        public DictationModeCmd(ViewModelBase viewModel)
        {
            ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.DictateMode();
        }
    }
}
