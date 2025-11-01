using MauiApp2.ViewModels;
using MauiApp2.Views.Employees;
using Services;
using ClassLibrary.Models;

namespace MauiApp2.Views;

public partial class EmployeesPage : ContentPage
	
{
	private EmployeesViewModel _viewModel;
    private JsonFileManager _jsonFileManager = new();
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

    public void SaveEmployeesToJsonClicked(object sender, EventArgs e)
    {
        _jsonFileManager.Save(_viewModel.Employees.ToList());
        DisplayAlert("Success", "Employees are saved to JSON file.", "OK");
    }

    public void LoadEmployeesFromJsonClicked(object sender, EventArgs e)
    {
        var loaded = _jsonFileManager.Load<Employee>();
        foreach (var item in loaded)
        {
            _viewModel.AddEmployee(item);
        }
        DisplayAlert("Success", "Employees loaded from JSON file.", "OK");
    }
}