using FluentMigrator.Runner;
using ImportApp.Migrations;

namespace ImportApp.Extensions;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            try
            {
                databaseService.CreateDatabase("excelimportdb");
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
            catch
            {
                //log errors or ...
                throw;
            }
        }

        return host;
    }
}