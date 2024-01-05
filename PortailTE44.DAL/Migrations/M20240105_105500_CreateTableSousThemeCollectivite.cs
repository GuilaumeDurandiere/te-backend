using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240105_105500)]
    public class M20240105_105500_CreateTableSousThemeCollectivite : Migration
    {
        public override void Up()
        {
            Create.Table("SousThemeCollectivite")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("SousThemeId").AsInt32().NotNullable().ForeignKey("SousTheme", "Id")
                .WithColumn("CollectiviteId").AsInt32().NotNullable().ForeignKey("Collectivite", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_SousThemeCollectivite_SousThemeId_SousTheme_Id").OnTable("SousThemeCollectivite");
            Delete.ForeignKey("FK_SousThemeCollectivite_CollectiviteId_Collectivite_Id").OnTable("SousThemeCollectivite");
            Delete.Table("SousThemeCollectivite");
        }
    }
}
