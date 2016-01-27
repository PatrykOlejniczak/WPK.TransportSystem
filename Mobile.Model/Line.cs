using System.Collections.Generic;

namespace Mobile.Model
{
    public class Line
    {
        public string Name { get; set; }
        public bool Direction { get; set; }
        public List<BusStop> BusStops { get; set; }       
    }
}