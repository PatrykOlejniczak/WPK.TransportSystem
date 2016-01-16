using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Employee : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string AreaCode { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime? EndDate { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}