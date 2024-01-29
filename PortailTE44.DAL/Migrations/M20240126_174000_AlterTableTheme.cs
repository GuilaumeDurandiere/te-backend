using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240126_174000)]
    public class M20240126_174000_AlterTableTheme : Migration
    {
        public override void Up()
        {
            Alter.Table("Theme").AlterColumn("Description").AsString(Int32.MaxValue).Nullable();
        }

        public override void Down()
        {
        }
    }
}
