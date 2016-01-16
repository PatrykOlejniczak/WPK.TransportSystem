using System.Collections.Generic;

namespace Data.Entities
{
    public class Line
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<BusStopOnLine> BusStopOnLines { get; private set; }

        public Line()
        {
            BusStopOnLines = new HashSet<BusStopOnLine>();
        }
    }
}