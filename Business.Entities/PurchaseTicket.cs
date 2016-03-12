using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class PurchaseTicket : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public DateTime DateOfPurchase { get; set; }

        [DataMember]
        public string DeviceId { get; set; }

        [DataMember]
        public string FirstNameTicketOwner { get; set; }

        [DataMember]
        public string LastNameTicketOwner { get; set; }

        [DataMember]
        public string DocumentIdentificationNumber { get; set; }

        [DataMember]
        public int TicketId { get; set; }

        [DataMember]
        public int? DiscountId { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}