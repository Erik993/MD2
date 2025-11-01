using MauiApp2.Views;
using MauiApp2.ViewModels;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private EmployeesViewModel _employeesViewModel;
        public MainPage(EmployeesViewModel employeesViewModel)
        {
            InitializeComponent();
            _employeesViewModel = employeesViewModel;
        }

        private async void EmployeeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeesPage(_employeesViewModel));
        }

    }
}
