using RPGManager.PersistenceCore.Repositories;
using RPGManager.Spell.Application.Repositories;
using RPGManager.Spell.Persistence.Context;

namespace RPGManager.Spell.Persistence.Repositories
{
    public class SpellRepository : Repository, ISpellRepository
    {
        public SpellRepository(SpellContext dbContext) : base(dbContext)
        {
        }
    }
}
