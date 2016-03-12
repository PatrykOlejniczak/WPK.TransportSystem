namespace Data.Entities
{
    public class Photo
    {
        public int Id { get; set; }    
        public string Name { get; set; }    
        public byte[] File { get; set; }
        public bool IsDeleted { get; set; }

        public int NewsId { get; set; }
        public virtual News News { get; set; }         
    }
}