namespace WPF_BIOSTAR2_APPLICATION
{
    using System.Windows;
    using WPF_BIOSTAR2_APPLICATION.ViewModels;
    using WPF_BIOSTAR2_APPLICATION.Views;
    public partial class App : Application
    {

        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        MainWindowViewModel mainWindowViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindowView>();
            displayRootRegistry.RegisterWindowType<DialogWindowViewModel, DialogWindow>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            mainWindowViewModel = new MainWindowViewModel();
            await displayRootRegistry.ShowModalPresentation(mainWindowViewModel);
            Shutdown();
        }
    }
}
