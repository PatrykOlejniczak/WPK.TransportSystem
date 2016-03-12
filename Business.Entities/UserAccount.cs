using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class UserAccount : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string HashPassword { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int EmployeeId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}