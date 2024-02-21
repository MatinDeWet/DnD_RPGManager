using Microsoft.EntityFrameworkCore;

namespace RPGManager.Spell.Persistence.Context
{
    public class SpellContext : DbContext
    {
        public SpellContext(DbContextOptions<SpellContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(SpellContext).Assembly);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
