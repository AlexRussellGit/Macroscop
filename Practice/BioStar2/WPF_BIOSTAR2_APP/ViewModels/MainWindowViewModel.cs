namespace WPF_BIOSTAR2_APPLICATION.ViewModels
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using System.ComponentModel;
    using WPF_BIOSTAR2_APPLICATION.Command;
    using WPF_BIOSTAR2_APPLICATION.Data.DataBase.Class;
    using WPF_BIOSTAR2_APPLICATION.Data.DataStructure.List;
    using WPF_BIOSTAR2_APPLICATION.RequestResponse.SearchEvent;
    using APIClassLibrary;

    public class MainWindowViewModel : BasicViewModel
{
        // Закрытые поля команд
        

        private ICommand _openDialogWindow;
              
        public ICommand OpenDialogWindow
        {
            get
            {
                if (_openDialogWindow == null)
                {
                    _openDialogWindow = new OpenDialogWindowCommand(this);
                }
                return _openDialogWindow;
            }
        }
        public ICollectionView SearchEventFields
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }


        private static Nullable<DateTime> myDateTimeStartProperty = null;
        public Nullable<DateTime> MyDateTimeStartProperty
        {
            get
            {
                if (myDateTimeStartProperty == null)
                {
                    myDateTimeStartProperty = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
                }
                return myDateTimeStartProperty;
            }
            set
            {
                myDateTimeStartProperty = value;
                OnPropertyChanged("MyDateTimeProperty");
            }
        }
        private static Nullable<DateTime> myDateTimeEndProperty = null;
        public Nullable<DateTime> MyDateTimeEndProperty
        {
            get
            {
                if (myDateTimeEndProperty == null)
                {
                    myDateTimeEndProperty = DateTime.Today;
                }
                return myDateTimeEndProperty;
            }
            set
            {
                myDateTimeEndProperty = value;
                OnPropertyChanged("MyDateTimeProperty");
            }
        }
        public static Nullable<DateTime> DatePickerStartSelectedDay()
        {
            return myDateTimeStartProperty;
        }
        public static Nullable<DateTime> DatePickerEndSelectedDay()
        {
            return myDateTimeEndProperty;
        }
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata("", FilterText_Chanded));

        private static void FilterText_Chanded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as MainWindowViewModel;
            if (current != null)
            {
                current.SearchEventFields.Filter = null;
                current.SearchEventFields.Filter = current.FilterList;
            }
        }

        public MainWindowViewModel()
        {
            this.searchEventButtonCommand = new SearchEventButtonCommand(this);
            SearchEventFields = CollectionViewSource.GetDefaultView(SearchEventList.GetElement());
            SearchEventFields.Filter = FilterList;
        }

        public SearchEventButtonCommand searchEventButtonCommand { get; set; }
        private bool FilterList(object obj) // Фильтр
        { 
            SearchEventClass current = obj as SearchEventClass;
            if (!string.IsNullOrWhiteSpace(FilterText) && current != null && !current.Date.Contains(FilterText) && !current.Door.Contains(FilterText) && !current.DeviceId.Contains(FilterText) && !current.Device.Contains(FilterText) && !current.UserGroup.Contains(FilterText) && !current.User.Contains(FilterText) && !current.Event.Contains(FilterText))
            {
                return false;
            }
            return true;
        }

        public void SearchEventButtonClickMethod()
        {
            try
            {
                if (User.LoginValue!=null)
                {
                    Search.SearchEventListResponse(DatePickerStartSelectedDay(), DatePickerEndSelectedDay());
                }
                else
                {
                    MessageBox.Show("Error: Invalid command! Login required!");
                }
            }
            catch (Exception e)
            {
                File.WriteAllText("ErrorLog", e.ToString());
                MessageBox.Show($"Error! Try Check Login!\n\nError Info: {e}");
            }
        }

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ICollectionView), typeof(MainWindowViewModel), new PropertyMetadata(null));
    }

    abstract class MyCommand : ICommand
    {
        protected MainWindowViewModel _mainWindowVeiwModel;

        public MyCommand(MainWindowViewModel mainWindowVeiwModel)
        {
            _mainWindowVeiwModel = mainWindowVeiwModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }

    class OpenDialogWindowCommand : MyCommand
    {
        public OpenDialogWindowCommand(MainWindowViewModel mainWindowVeiwModel) : base(mainWindowVeiwModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override async void Execute(object parameter)
        {
            await (Application.Current as App).displayRootRegistry.ShowModalPresentation(new DialogWindowViewModel());
        }
    }
}