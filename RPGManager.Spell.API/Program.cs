using Microsoft.EntityFrameworkCore;
using RPGManager.ApplicationCore;
using RPGManager.Spell.Persistence;
using RPGManager.Spell.Persistence.Context;
using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((ctx, lc) =>
            lc.ReadFrom.Configuration(ctx.Configuration)
        );

        builder.Services.RegisterSpellPersistence(
            SpellPersistenceRegistration.ConfigureSpellContextForPostgresDb(builder.Configuration.GetConnectionString("SpellDB")!)
        );

        builder.Services.RegisterApplicationCore();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSerilogRequestLogging();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        ApplyMigration(app);

        app.Run();
    }

    internal static void ApplyMigration(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        if (serviceScope.ServiceProvider.GetRequiredService<SpellContext>().Database.GetPendingMigrations().Count() > 0)
            serviceScope.ServiceProvider.GetRequiredService<SpellContext>().Database.Migrate();
    }
}
