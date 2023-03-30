using FluentMigrator;
namespace ImportApp.Migrations;

[Migration(202303300001)]
public class InitialTables_202303300001: Migration
{
    public override void Up()
    {
        Create.Table("Personnel")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("PayrollNumber").AsString()
            .WithColumn("Forename").AsString()
            .WithColumn("Surename").AsString()
            .WithColumn("DateOfBirth").AsDateTime2()
            .WithColumn("Telephone").AsInt64()
            .WithColumn("Mobile").AsInt64()
            .WithColumn("Address").AsString()
            .WithColumn("Address2").AsString()
            .WithColumn("Postcode").AsString()
            .WithColumn("EmailHome").AsString()
            .WithColumn("StartDate").AsDateTime2();
    }

    public override void Down()
    {
        Delete.Table("Personnel");
    }
}