using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240123_101000)]
    public class M20240123_101000_DropTableSousThemeCollectivite : Migration
    {
        public override void Up()
        {
            if (Schema.Table("SousThemeCollectivite").Exists())
            {
                Delete.ForeignKey("FK_SousThemeCollectivite_SousThemeId_SousTheme_Id").OnTable("SousThemeCollectivite");
                Delete.ForeignKey("FK_SousThemeCollectivite_CollectiviteId_Collectivite_Id").OnTable("SousThemeCollectivite");
                Delete.Table("SousThemeCollectivite");
            }
        }

        public override void Down()
        {
            Create.Table("SousThemeCollectivite")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("SousThemeId").AsInt32().NotNullable().ForeignKey("SousTheme", "Id")
                .WithColumn("CollectiviteId").AsInt32().NotNullable().ForeignKey("Collectivite", "Id");
        }
    }
}
