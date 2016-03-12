using System.Collections.Generic;

namespace Data.Entities
{
    public class TicketType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Ticket> Tickets { get; private set; }

        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

    }
}