using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240105_104500)]
    public class M20240105_104500_CreateTableCollectivite : Migration
    {
        public override void Up()
        {
            Create.Table("Collectivite")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Collectivite");
        }
    }
}
