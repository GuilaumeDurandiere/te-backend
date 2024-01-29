using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240126_173500)]
    public class M20240126_173500_AlterTableEtape : Migration
    {
        public override void Up()
        {
            Alter.Table("Etape").AlterColumn("Description").AsString(Int32.MaxValue).Nullable();
        }

        public override void Down()
        {
        }
    }
}
