using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Factories;
using Interfaces;
using Interfaces.Library;
using Library;
using Services;

namespace ApplicationManager;

public class ApplicationDataManager : IDataManager
{

    public EmployeeRepository EmployeeRepo { get; set; } = new EmployeeRepository();
    public ITSupportRepository ITSupportRepo { get; set; } = new ITSupportRepository();
    public TicketRepository TicketRepo { get; set; } = new TicketRepository();
    public AssignmentRepository AssignmentRepo { get; set; } = new AssignmentRepository();

    private JsonFileManager _fileManager = new JsonFileManager();

    private EmployeeFactory _employeeFactory = new EmployeeFactory();
    private ITSupportFactory _itSupportFactory = new ITSupportFactory();
    private TicketFactory? _ticketFactory = null; //= new TicketFactory(); null because Employees should be passed
    private AssignmentFactory? _assignmentFactory = null; // = new AssignmentFactory(); null beceause ITSupports and Tickets should be passed

    /*
    public void Print()
    {
        EmployeeRepo.Print();
        ITSupportRepo.Print();
        TicketRepo.Print();
        AssignmentRepo.Print();
    }*/

    public void Save()
    {
        _fileManager.Save(EmployeeRepo.GetAll());
        _fileManager.Save(ITSupportRepo.GetAll());
        _fileManager.Save(TicketRepo.GetAll());
        _fileManager.Save(AssignmentRepo.GetAll());
    }

    public void Reset()
    {
        EmployeeRepo.Reset();
        ITSupportRepo.Reset();
        TicketRepo.Reset();
        AssignmentRepo.Reset();
    }

    public void Load()
    {
        //WriteLine("---Loading Data from json---");
        EmployeeRepo.Reset();

        //load all the Employee objects 
        var loadedEmployees = _fileManager.Load<Employee>();
        //save all the loaded elements in repository
        foreach (var el in loadedEmployees)
        {
            EmployeeRepo.Add(el);
        }

        var loadedITSupposts = _fileManager.Load<ITSupport>();
        foreach (var el in loadedITSupposts)
        {
            ITSupportRepo.Add(el);
        }

        var loadedTickets = _fileManager.Load<Ticket>();
        foreach (var el in loadedTickets)
        {
            TicketRepo.Add(el);
        }

        var loadedAssignments = _fileManager.Load<Assignment>();
        foreach (var el in loadedAssignments)
        {
            AssignmentRepo.Add(el);
        }

        //WriteLine("---Loading Completed---");
    }

    /*
    1. Create Employees and ITSupports
    2. Update _ticketFactory. Need to pass all the Employees to the _ticketFactory
    3. Create Tickets
    4. Update _assignmentFactory. Need to pass all the ITSupports and Tickets to the _assignmentFactory
    5. Create Assignments
    */
    public void CreateTestData(int count)
    {
        //WriteLine($"---Generating {count} test objects---");
        Reset();

        for (int i = 0; i < count; i++)
        {
            EmployeeRepo.Add(_employeeFactory.CreateItem(i));
            ITSupportRepo.Add(_itSupportFactory.CreateItem(i));
        }

        //update factory, because Employees were made in previous step
        _ticketFactory = new TicketFactory(EmployeeRepo);
        for (int i = 0; i < count; i++)
        {
            TicketRepo.Add(_ticketFactory.CreateItem(i));
        }

        _assignmentFactory = new AssignmentFactory(ITSupportRepo, TicketRepo);
        for (int i = 0; i < count; i++)
        {
            AssignmentRepo.Add(_assignmentFactory.CreateItem());
        }
        Console.WriteLine("--- Test Data Generation Complete ---");
    }
    
}
