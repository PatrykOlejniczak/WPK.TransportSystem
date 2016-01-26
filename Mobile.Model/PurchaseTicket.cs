using System;

namespace Mobile.Model
{
    public class PurchaseTicket
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public string DeviceId { get; set; }
        public string FirstNameTicketOwner { get; set; }
        public string LastNameTicketOwner { get; set; }
        public string TicketName { get; set; }
        public int TicketId { get; set; }
        public int? DiscountId { get; set; }
        public int CustomerId { get; set; }
    }
}