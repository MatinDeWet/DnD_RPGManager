using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPGManager.ApplicationCore.Repositories;
using RPGManager.Spell.Application.Repositories;
using RPGManager.Spell.Persistence.Context;
using RPGManager.Spell.Persistence.Repositories;
using System.Reflection;

namespace RPGManager.Spell.Persistence
{
    public static class SpellPersistenceRegistration
    {
        public static void RegisterSpellPersistence(this IServiceCollection services, Action<DbContextOptionsBuilder> configureContext)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<SpellContext>(configureContext);
            services.AddScoped<ISpellRepository, SpellRepository>();
        }

        public static Action<DbContextOptionsBuilder> ConfigureSpellContextForPostgresDb(string connectionString)
        {
            var migrationAssembly = typeof(SpellContext).GetTypeInfo().Assembly.GetName().Name;

            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            return (options) =>
            {
                options.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(migrationAssembly));
            };
        }
    }
}
