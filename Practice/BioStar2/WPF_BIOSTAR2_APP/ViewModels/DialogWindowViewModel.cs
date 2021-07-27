namespace WPF_BIOSTAR2_APPLICATION.ViewModels
{
    using WPF_BIOSTAR2_APPLICATION.Command;
    using APIClassLibrary;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System;
    using System.IO;
    using System.Windows;
    public class DialogWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static string loginValue = "admin";
        public static string passwordValue = "admin123";
        string _comboboxitemselected = null;

        public string LoginValue
        {
            get { return loginValue; }
            set { OnPropertyChanged(); loginValue = value; }
        }
        public string PasswordValue
        {
            get { return passwordValue; }
            set { OnPropertyChanged(); passwordValue = value; }
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string ComboboxItemSelected
        {
            get { return _comboboxitemselected; }
            set { OnPropertyChanged(); _comboboxitemselected = value; } // NotifyPropertyChanged
        }
        public DialogButtonCommand DialogWindowButtonCommand { get; set; }

        public DialogWindowViewModel()
        {
            this.DialogWindowButtonCommand = new DialogButtonCommand(this);
        }

        public void DialogWindowButtonClickMethod()
        {
            try
            {
                if (Internet.CheckConnection())
                {
                    if (User.SessionIntake(LoginValue, PasswordValue))
                    {
                        MessageBox.Show("Successfully Logged In!");
                    }
                }
                else
                {
                    MessageBox.Show("Error! Please connect to Internet!");
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("ErrorLog", e.ToString());
                MessageBox.Show($"Unexpected Exception!\n\nError Info: {e}");
            }
        }
    }
}