using MauiApp2.ViewModels;
using MauiApp2.Views.Employees;

namespace MauiApp2.Views;

public partial class EmployeesPage : ContentPage
	
{
	private EmployeesViewModel _viewModel;
	public EmployeesPage(EmployeesViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
        //BindingContext = _viewModel;
    }

    private async void AddEmployeeButtonClicked(object sender, EventArgs e)
	{
        // go to the AddEmployeePage and pass the same ViewModel
        await Navigation.PushAsync(new AddEmployeePage(_viewModel));
    }

    private async void ShowEmployeesButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShowEmployeesPage(_viewModel));
    }
}