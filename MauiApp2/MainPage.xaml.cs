using MauiApp2.Views;
using MauiApp2.ViewModels;
using MauiApp2.Views.ITSupport;
using Services;
using ClassLibrary.Models;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private EmployeesViewModel _employeesViewModel;
        private ITSupportsViewModel _itSupportsViewModel;
        private JsonFileManager _jsonFileManager;
       
        public MainPage(EmployeesViewModel employeesViewModel, ITSupportsViewModel itSupportsViewModel, JsonFileManager jsonFileManager)
        {
            InitializeComponent();
            _employeesViewModel = employeesViewModel;
            _itSupportsViewModel = itSupportsViewModel;
            _jsonFileManager = jsonFileManager;
        }
        

        //redirecting to Employee Page
        private async void EmployeeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeesPage(_employeesViewModel));
        }


        //redirecting to ITSupport Page
        private async void ITSupportButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ITSupportsPage(_itSupportsViewModel));
        }

        /*
        private void SaveAllDataToJsonClicked(object sender, EventArgs e)
        {
            //before saving the collection, need to cast it to List, beacause the jsonFileManager works with List
            _jsonFileManager.Save(_employeesViewModel.Employees.ToList());
            _jsonFileManager.Save(_itSupportsViewModel.ITSupports.ToList());
            DisplayAlert("Success", "Employees amd Supports saved to JSON file.", "OK");
        }

        //loading objects. Can load duplicates
        private void LoadAllDataFromJsonClicked(object sender, EventArgs e)
        {
            var loadedEmpls = _jsonFileManager.Load<Employee>();
            foreach(var element in loadedEmpls)
            {
                _employeesViewModel.AddEmployee(element);
            }

            var loadedItSups = _jsonFileManager.Load<ITSupport>();
            foreach(var element in loadedItSups)
            {
                _itSupportsViewModel.AddITSupport(element);
            }

            DisplayAlert("Success", "Employees loaded from JSON file.", "OK");
        }*/

    }
}
