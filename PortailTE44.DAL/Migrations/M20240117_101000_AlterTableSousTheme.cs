using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240117_101000)]
    public class M20240117_101000_AlterTableSousTheme : Migration
    {
        public override void Up()
        {
            Alter.Table("SousTheme").AlterColumn("MailReferent").AsString().Nullable();
        }

        public override void Down()
        {
        }
    }
}
