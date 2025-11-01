using MauiApp2.ViewModels;
using Services;

namespace MauiApp2
{
    public partial class App : Application
    {
        public EmployeesViewModel EmployeesVM { get; } = new();
        public ITSupportsViewModel ITSupportVM { get; } = new();
        public JsonFileManager JsonManager { get; } = new();
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //This is required for PushAsync to work
            MainPage = new NavigationPage(new MainPage(EmployeesVM, ITSupportVM,  JsonManager));
        }
    }
}
