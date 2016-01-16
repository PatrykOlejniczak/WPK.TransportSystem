using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class News : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}