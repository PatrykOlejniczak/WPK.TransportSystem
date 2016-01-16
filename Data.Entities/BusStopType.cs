using System.Collections.Generic;

namespace Data.Entities
{
    public class BusStopType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<BusStop> BusStops { get; private set; }

        public BusStopType()
        {
            BusStops = new HashSet<BusStop>();
        }
    }
}