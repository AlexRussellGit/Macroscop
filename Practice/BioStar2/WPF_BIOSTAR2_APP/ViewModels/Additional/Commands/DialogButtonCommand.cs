using WPF_BIOSTAR2_APPLICATION.ViewModels;
using System;
using System.Windows.Input;

namespace WPF_BIOSTAR2_APPLICATION.Command
{
    public class DialogButtonCommand : ICommand // Is a Button Command Of Dialog Window Which Starts The Login 
    {

        public DialogWindowViewModel DialogWindowViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public DialogButtonCommand(DialogWindowViewModel dialogViewModel)
        {
            this.DialogWindowViewModel = dialogViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.DialogWindowViewModel.DialogWindowButtonClickMethod(); // The Method which will Invoce after clicking
        }
    }
}
