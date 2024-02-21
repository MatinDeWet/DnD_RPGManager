using Microsoft.EntityFrameworkCore;
using RPGManager.ApplicationCore.Exceptions;
using RPGManager.ApplicationCore.Repositories;
using RPGManager.DomainCore.Common;

namespace RPGManager.PersistenceCore.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void InsertAsync<T>(T obj) where T : class
        {
            _context.Add(obj);
        }

        public void UpdateAsync<T>(T obj) where T : class
        {
            _context.Update(obj);
        }

        public async Task DeleteAsync<TKey, T>(TKey id, CancellationToken cancellationToken) where T : class, IKeyedEntity<TKey> where TKey : struct, IEquatable<TKey>
        {
            var obj = await Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

            if (obj == null)
            {
                throw new NotFoundException($"{nameof(T)} with id {id} could not be found");
            }

            _context.Remove(obj);
        }
    }
}
