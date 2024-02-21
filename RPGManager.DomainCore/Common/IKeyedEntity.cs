namespace RPGManager.DomainCore.Common
{
    public interface IKeyedEntity<TKey> where TKey : struct, IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
