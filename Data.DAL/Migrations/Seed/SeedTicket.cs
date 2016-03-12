using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    internal class SeedTicket : ISeedMethod
    {
        private readonly DataContext _dataContext;
        private readonly IRepository<TicketType> _ticketTypeRepository;

        private readonly List<Ticket> _tickets = new List<Ticket>()
        {
            new Ticket() { Id = 1,  Name = "10 minutes", Duration = new Duration(0,0,10),  Price = 2.0,   IsDeleted = false },
            new Ticket() { Id = 2,  Name = "15 minutes", Duration = new Duration(0,0,15),  Price = 2.5,   IsDeleted = false },
            new Ticket() { Id = 3,  Name = "30 minutes", Duration = new Duration(0,0,30),  Price = 3.6,   IsDeleted = false },
            new Ticket() { Id = 4,  Name = "60 minutes", Duration = new Duration(0,0,60),  Price = 4.8,   IsDeleted = false },
            new Ticket() { Id = 5,  Name = "2 hours",    Duration = new Duration(0,2,0),   Price = 6.0,   IsDeleted = false },
            new Ticket() { Id = 6,  Name = "4 hours",    Duration = new Duration(0,4,0),   Price = 8.0,   IsDeleted = false },
            new Ticket() { Id = 7,  Name = "24 hours",   Duration = new Duration(0,24,0),  Price = 12.0,  IsDeleted = false },
            new Ticket() { Id = 8,  Name = "48 hours",   Duration = new Duration(0,48,0),  Price = 18.0,  IsDeleted = false },
            new Ticket() { Id = 9,  Name = "14 days",    Duration = new Duration(14,0,0),  Price = 40.0,  IsDeleted = false },
            new Ticket() { Id = 10, Name = "30 days",    Duration = new Duration(30,0,0),  Price = 60.0,  IsDeleted = false },
            new Ticket() { Id = 11, Name = "90 days",    Duration = new Duration(90,0,0),  Price = 160.0, IsDeleted = false },
            new Ticket() { Id = 12, Name = "180 days",   Duration = new Duration(180,0,0), Price = 300.0, IsDeleted = false },
            new Ticket() { Id = 13, Name = "360 days",   Duration = new Duration(360,0,0), Price = 480.0, IsDeleted = false }
        };

        public SeedTicket(DataContext dataContext, IRepository<TicketType> ticketTypeRepository)
        {
            _dataContext = dataContext;
            _ticketTypeRepository = ticketTypeRepository;
        }

        public void FillTable()
        {
            AddTicketTypes();

            foreach (var ticket in _tickets)
            {
                _dataContext.Set<Ticket>().AddOrUpdate(ticket);
            }

            _dataContext.SaveChanges(); 
        }

        private void AddTicketTypes()
        {
            _ticketTypeRepository.EnrollUnitOfWork(_dataContext);
            var ticketTypeList = _ticketTypeRepository.FindAll().ToList();

            foreach (var ticket in _tickets)
            {
                if (ticket.Duration.Days > 0)
                {
                    ticket.TicketType = ticketTypeList.Find(type => type.Name == "OneTime");
                }
                else
                {
                    ticket.TicketType = ticketTypeList.Find(type => type.Name == "Season");
                }
            }
        }
    }
}