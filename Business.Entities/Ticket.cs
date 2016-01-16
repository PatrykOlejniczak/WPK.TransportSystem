using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Ticket : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int TicketTypeId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}