using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class BusStopOnLine : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public bool Direction { get; set; }
        [DataMember]
        public int NumberStopOnLine { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public int LineId { get; set; }
        [DataMember]
        public int BusStopId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}