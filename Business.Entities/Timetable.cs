using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Timetable : IExtensibleDataObject
    {
         [DataMember]
         public int? Id { get; set; }

        [DataMember]
        public TimeSpan DepartureTime { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int BusStopOnLineId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}