namespace RPGManager.DomainCore.Common
{
    public abstract class BaseEntity : IKeyedEntity<int>
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime? DateUpdated { get; set; }
    }
}
