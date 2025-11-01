using AbstractClasses;
using Library;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp2.ViewModels
{
    public class EmployeesViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; } = new();

        public int NewUserId { get; set; }
        public string NewUserName { get; set; } = string.Empty;
        public string NewEmail { get; set; } = string.Empty;
        public bool NewIsActve { get; set; }
       


        public void AddEmployee()
        {
            Employee empl = new(NewUserId, NewUserName, NewEmail, NewIsActve);
            Employees.Add(empl);
        }

    }
}
