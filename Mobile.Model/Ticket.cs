using System;

namespace Mobile.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public int TicketTypeId { get; set; }
    }
}