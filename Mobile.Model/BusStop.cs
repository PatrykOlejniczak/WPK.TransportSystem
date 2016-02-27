namespace Mobile.Model
{
    public class BusStop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOnLine { get; set; }
        public bool Direction { get; set; }
        public bool IsFavorite { get; set; } 
    }
}