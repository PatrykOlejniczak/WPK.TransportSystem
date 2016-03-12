using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Discount : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Percent { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}