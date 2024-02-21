using RPGManager.ApplicationCore.Repositories;
using RPGManager.Spell.Persistence.Context;

namespace RPGManager.Spell.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SpellContext _ctx;

        public UnitOfWork(SpellContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            await _ctx.SaveChangesAsync(cancellationToken);
        }
    }
}
