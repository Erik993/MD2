using System;
using Library;
using System.Linq;
using ClassLibrary.Models;

namespace Factories;

public class AssignmentFactory
{
    private ITSupportRepository _itSupportRepo;
    private TicketRepository _ticketRepo;

    private Random _rand = new Random();

    
    public AssignmentFactory(ITSupportRepository itSupRepo, TicketRepository ticketRepo)
    {
        _itSupportRepo = itSupRepo;
        _ticketRepo = ticketRepo;
    }


    public Assignment CreateItem()
    {
        var allItSupports = _itSupportRepo.GetAll(); // save all the elements
        var allTickets = _ticketRepo.GetAll(); // save all the elements

        ITSupport? itSupport = null;
        Ticket? ticket = null;

        if (allItSupports.Count > 0)
        {
            //save random element from sequence
            itSupport = allItSupports.ElementAt(_rand.Next(0, allItSupports.Count()));
        }

        if (allTickets.Count > 0)
        {
            //save random element from sequence
            ticket = allTickets.ElementAt(_rand.Next(0, allTickets.Count()));
        }

        return new Assignment(
            // if itsupport is null, then new support with default data is created
            support: itSupport ?? new ITSupport(0, "default Support", "defSup@gmail.com", true, ITSupport.Role.HelpDesk),

            // if ticket is null, then new ticket with default data is created with created by as null
            ticket: ticket ?? new Ticket("default Title", "default description", 1, 0, null, Ticket.StatusEnum.Open, false),
            comment: "default comment"
        );
    }
}