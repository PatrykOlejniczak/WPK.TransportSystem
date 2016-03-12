using System.Collections.Generic;

namespace Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string HashPassword { get; set; }

        public double AccountBallance { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<BoostAccount> BoostAccounts { get; private set; }
        public virtual ICollection<PurchaseTicket> PurchaseTickets { get; private set; }

        public Customer()
        {
            BoostAccounts = new HashSet<BoostAccount>();
            PurchaseTickets = new HashSet<PurchaseTicket>();
        } 
    }
}