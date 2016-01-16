using System;

namespace Data.Entities
{
    public class Timetable
    {
        public int Id { get; set; }

        public TimeSpan DepartureTime { get; set; }

        public bool IsDeleted { get; set; }

        public int BusStopOnLineId { get; set; }
        public virtual BusStopOnLine BusStopOnLine { get; set; }
    }
}