using System.Collections.Generic;

namespace Data.Entities
{
    public class BusStopOnLine
    {
        public int Id { get; set; } 

        public bool Direction { get; set; }

        public int NumberStopOnLine { get; set; }
        public bool IsDeleted { get; set; }

        public int LineId { get; set; }
        public virtual Line Line { get; set; }

        public int BusStopId { get; set; }
        public virtual BusStop BusStop { get; set; }

        public virtual ICollection<Timetable> Timetables { get; private set; }

        public BusStopOnLine()
        {
            Timetables = new HashSet<Timetable>();
        }
    }
}