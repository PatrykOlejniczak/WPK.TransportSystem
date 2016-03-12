namespace Mobile.Model
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Percent { get; set; }
        public bool IsDeleted { get; set; }
    }
}