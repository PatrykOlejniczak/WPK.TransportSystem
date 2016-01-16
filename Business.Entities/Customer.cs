using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Customer : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string HashPassword { get; set; }

        [DataMember]
        public double AccountBallance { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}