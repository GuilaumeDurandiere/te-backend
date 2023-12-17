using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231213_170000)]
    public class M20231213_170000_CreateTableWorkflow : Migration
    {
        public override void Up()
        {
            Create.Table("Workflow")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("Actif").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Workflow");
        }
    }
}
