namespace ECommerceProject.src.Utilities
{
    public class BaseClass
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public BaseClass() { }
        public BaseClass(Guid id, DateTime createdAt, DateTime updatedAt)
        {
            id = Guid.Empty;
            createdAt = DateTime.UtcNow;
            updatedAt = DateTime.UtcNow;
            ID = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}