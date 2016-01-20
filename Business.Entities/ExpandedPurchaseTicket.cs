using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class ExpandedPurchaseTicket : PurchaseTicket
    {
        [DataMember]
        public string TicketName { get; set; }
    }
}
