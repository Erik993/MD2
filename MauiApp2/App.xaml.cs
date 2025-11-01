using MauiApp2.ViewModels;

namespace MauiApp2
{
    public partial class App : Application
    {
        public EmployeesViewModel EmployeesVM { get; } = new();
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //This is required for PushAsync to work
            MainPage = new NavigationPage(new MainPage(EmployeesVM));
        }
    }
}
