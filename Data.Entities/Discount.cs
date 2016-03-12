using System.Collections.Generic;

namespace Data.Entities
{
    public class Discount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Percent { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<PurchaseTicket> PurchaseTickets { get; private set; } 

        public Discount()
        {
            PurchaseTickets = new HashSet<PurchaseTicket>();
        }
    }
}