using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class BusStop : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int BusStopTypeId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}