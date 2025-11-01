using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library;

namespace Factories;

public class TicketFactory
{
    //private List<Employee> _employees;
    private EmployeeRepository _employeeRepo;
    private Random _rand = new Random();


    //public TicketFactory(List<Employee> employees)
    public TicketFactory(EmployeeRepository employeeRepository)
    {
        _employeeRepo = employeeRepository;
    }


    public Ticket CreateItem(int index)
    {
        //create random integer to assign it in object
        var employees = _employeeRepo.GetAll();
        int randNum = _rand.Next(0, 100);

        Employee? createdBy = null;
        if (employees.Count > 0)
        {
            int randIndex = _rand.Next(0, employees.Count);
            createdBy = employees[randIndex];
        }

        return new Ticket(
                title: $"title{randNum}",
                description: $"description{randNum}",
                priority: randNum,
                ticketId: index,
                createdBy: createdBy ?? new Employee(0, "DefaultCreator", "default@gmail.com", true, DateTime.Now),
                status: Ticket.StatusEnum.Open,
                isResolved: false
            );
    }
        
}
