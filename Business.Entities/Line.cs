using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Line : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public string Name { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}