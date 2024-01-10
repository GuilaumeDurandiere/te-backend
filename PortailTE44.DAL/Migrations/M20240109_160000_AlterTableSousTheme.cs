using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240109_160000)]
    public class M20240109_160000_AlterTableSousTheme : Migration
    {
        public override void Up()
        {
            Alter.Table("SousTheme").AddColumn("RefTypeOffreId").AsInt32().NotNullable().ForeignKey("RefTypeOffre", "Id").WithDefaultValue(1);

            if (Schema.Table("SousTheme").Column("HorsTravaux").Exists())
                Delete.Column("HorsTravaux").FromTable("SousTheme");

            if (Schema.Table("SousTheme").Column("DemandeSimple").Exists())
                Delete.Column("DemandeSimple").FromTable("SousTheme");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_SousTheme_RefTypeOffreId_RefTypeOffre_Id").OnTable("SousTheme");
            Delete.Column("RefTypeOffreId").FromTable("SousTheme");
        }
    }
}
