using System;

namespace Data.Entities
{
    public class DistanceBetweenStops
    {
        public int Id { get; set; }
        
        public TimeSpan TravelTime { get; set; }
        
        public double DistanceInKilometers { get; set; }
        public bool IsDeleted { get; set; }

        public int FirstBusStopId { get; set; }
        public virtual BusStop FirstBusStop { get; set; }

        public int SecondBusStopId { get; set; }
        public virtual BusStop SecondBusStop { get; set; }
    }
}