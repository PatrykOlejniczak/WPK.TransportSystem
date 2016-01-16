using System.Collections.Generic;

namespace Data.Entities
{
    public class BusStop
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Street { get; set; }
        public bool IsDeleted { get; set; }

        public int BusStopTypeId { get; set; }
        public virtual BusStopType BusStopType { get; set; }

        public virtual ICollection<BusStopOnLine> BusStopOnLines { get; private set; }
        public virtual ICollection<DistanceBetweenStops> FirstBusStopInDistanceBetweenStopses { get; private set; }
        public virtual ICollection<DistanceBetweenStops> SecondBusStopInDistanceBetweenStopses { get; private set; }

        public BusStop()
        {
            BusStopOnLines = new HashSet<BusStopOnLine>();
            FirstBusStopInDistanceBetweenStopses = new HashSet<DistanceBetweenStops>();
            SecondBusStopInDistanceBetweenStopses = new HashSet<DistanceBetweenStops>();
        }
    }
}