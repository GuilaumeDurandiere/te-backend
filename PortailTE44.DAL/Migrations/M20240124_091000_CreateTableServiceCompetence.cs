using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240124_091000)]
    public class M20240124_091000_CreateTableServiceCompetence : Migration
    {
        public override void Up()
        {
            Create.Table("ServiceCompetence")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("SydenetId").AsString().NotNullable()
                .WithColumn("Competence").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("ServiceCompetence");
        }
    }
}
