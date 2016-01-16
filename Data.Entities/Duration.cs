namespace Data.Entities
{
    public class Duration
    { 
        public int Days { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public Duration()
        {
            
        }

        public Duration(int days, int hours, int minutes)
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

    }
}