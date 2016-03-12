namespace Data.Entities
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }
        public bool IsDeleted { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}