using RPGManager.DomainCore.Common;

namespace RPGManager.ApplicationCore.Repositories
{
    public interface IRepository
    {
        IQueryable<T> Set<T>() where T : class;

        void InsertAsync<T>(T obj) where T : class;
        void UpdateAsync<T>(T obj) where T : class;
        Task DeleteAsync<TKey, T>(TKey id, CancellationToken cancellationToken) where T : class, IKeyedEntity<TKey> where TKey : struct, IEquatable<TKey>;
    }
}
