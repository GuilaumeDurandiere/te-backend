using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240108_150500)]
    public class M20240108_150500_AlterTableSousTheme : Migration
    {
        public override void Up()
        {
            Alter.Table("SousTheme").AlterColumn("WorkflowId").AsInt32().Nullable();
        }

        public override void Down()
        {
        }
    }
}
