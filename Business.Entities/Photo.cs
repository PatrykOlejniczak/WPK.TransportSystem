using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Photo : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public byte[] File { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int NewsId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}