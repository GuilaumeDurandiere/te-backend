using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240125_150000)]
    public class M20240125_150000_AlterTableSousTheme : Migration
    {
        public override void Up()
        {
            Alter.Table("SousTheme").AddColumn("ServiceCompetenceId").AsInt32().Nullable().ForeignKey("ServiceCompetence", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_SousTheme_ServiceCompetenceId_ServiceCompetence_Id").OnTable("SousTheme");
            Delete.Column("ServiceCompetenceId").FromTable("SousTheme");
        }
    }
}
