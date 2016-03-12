using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Data.Core.Migrations.Seed
{
    public class SeedTicketType : ISeedMethod
    {
        private readonly DataContext _dataContext;

        private readonly  List<TicketType> _ticketTypes = new List<TicketType>()
        {
            new TicketType() { Id = 1, Name = "OneTime", Description = "Ticket for short time.", IsDeleted = false },
            new TicketType() { Id = 2, Name = "Season",  Description = "Ticket for long time.",  IsDeleted = false }
        };

        public SeedTicketType(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void FillTable()
        {
            foreach (var ticketType in _ticketTypes)
            {
                _dataContext.Set<TicketType>().AddOrUpdate(ticketType);
            }
            _dataContext.SaveChanges();
        }

    }
}