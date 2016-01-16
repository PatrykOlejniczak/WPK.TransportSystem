using System;
using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class DistanceBetweenStops : IExtensibleDataObject
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public TimeSpan TravelTime { get; set; }
        [DataMember]
        public double DistanceInKilometers { get; set; }
        [DataMember]
        public int FirstBusStopId { get; set; }
        [DataMember]
        public int SecondBusStopId { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}