using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Questionnaire : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}