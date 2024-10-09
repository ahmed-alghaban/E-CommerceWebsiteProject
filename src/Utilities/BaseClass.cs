namespace ECommerceProject.src.Utilities
{
    public class BaseClass
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set;} = DateTime.UtcNow;

        public BaseClass(){

            ID = Guid.Empty;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            
        }
        
    }
}