using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class BoostAccount : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public DateTime GeneratedDateTime { get; set; }

        [DataMember]
        public DateTime? DateOfBoost { get; set; }

        [DataMember]
        public int? CustomerId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}