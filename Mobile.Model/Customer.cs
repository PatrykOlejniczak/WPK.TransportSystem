namespace Mobile.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double AccountBallance { get; set; }
        public bool IsDeleted { get; set; }
    }
}