using System.Collections.Generic;

namespace Data.Entities
{
    public class Ticket
    {       
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Duration Duration { get; set; }

        public bool IsDeleted { get; set; }

        public int TicketTypeId { get; set; }
        public virtual TicketType TicketType { get; set; }

        public virtual ICollection<PurchaseTicket> PurchaseTickets { get; private set; }

        public Ticket()
        {
            PurchaseTickets = new HashSet<PurchaseTicket>();
        }

    }
}