using System;

namespace Data.Entities
{
    public class PurchaseTicket
    {
        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string DeviceId { get; set; }

        public string FirstNameTicketOwner { get; set; }

        public string LastNameTicketOwner { get; set; }

        public string DocumentIdentificationNumber { get; set; }

        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}