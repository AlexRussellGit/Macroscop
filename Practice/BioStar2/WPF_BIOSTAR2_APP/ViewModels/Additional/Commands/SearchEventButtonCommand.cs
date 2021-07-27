using WPF_BIOSTAR2_APPLICATION.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_BIOSTAR2_APPLICATION.Command
{
    public class SearchEventButtonCommand : ICommand // Is a Button Command Of Dialog Window Which Starts The Login 
    {

        public MainWindowViewModel MainWindowViewModel { get; set; }
        public event EventHandler CanExecuteChanged;

        public SearchEventButtonCommand(MainWindowViewModel mainWindowViewModel)
        {
            this.MainWindowViewModel = mainWindowViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.MainWindowViewModel.SearchEventButtonClickMethod(); // The Method which will Invoce after clicking
        }
    }
}
