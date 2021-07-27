using WPF_BIOSTAR2_APPLICATION.Data.DataStructure.List;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Input;

namespace WPF_BIOSTAR2_APPLICATION.Views
{
    public partial class MainWindowView : Window
    {

        public ICommand ExitCommand { get; }

        public MainWindowView()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //ExitCommand = new DelegateCommand(_ => Close());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string str1 = "10.04.2019";
        //    string str2 = "Door5";
        //    string str3 =  "43863";
        //    string str4 =  "Bio Star 1754830";
        //    string str5 ="UserLvl1";
        //    string str6 = "Awex";
        //    string str7 = "Door Opened";
        //    SearchEventList.Add(str1, str2, str3, str4, str5, str6, str7);
        //}
    }

    class DelegateCommand : ICommand
    {
        protected readonly Predicate<object> _canExecute;
        protected readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute) : this(execute, _ => true) { }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Action excute is null");
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
          => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
