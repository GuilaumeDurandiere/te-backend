using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240123_101500)]
    public class M20240123_101500_AlterTableCollectivite : Migration
    {
        public override void Up()
        {
            Alter.Table("Collectivite").AddColumn("SydenetId").AsString().NotNullable();
            Alter.Table("Collectivite").AddColumn("CodeInsee").AsString().NotNullable();
            Alter.Table("Collectivite").AddColumn("Siret").AsString().NotNullable();
            Alter.Table("Collectivite").AddColumn("CommunauteCommune").AsBoolean().NotNullable();
        }

        public override void Down()
        {
            if (Schema.Table("Collectivite").Column("SydenetId").Exists())
                Delete.Column("SydenetId").FromTable("Collectivite");

            if (Schema.Table("Collectivite").Column("CodeInsee").Exists())
                Delete.Column("CodeInsee").FromTable("Collectivite");

            if (Schema.Table("Collectivite").Column("CommunauteCommune").Exists())
                Delete.Column("CommunauteCommune").FromTable("Collectivite");

            if (Schema.Table("Collectivite").Column("Siret").Exists())
                Delete.Column("Siret").FromTable("Collectivite");
        }
    }
}
