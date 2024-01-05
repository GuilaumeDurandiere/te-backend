using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231229_130000)]
    public class M20231229_130000_CreateTableTheme : Migration
	{
        public override void Up()
        {
            Create.Table("Theme")
               .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
               .WithColumn("Libelle").AsString().NotNullable()
               .WithColumn("Description").AsString();
        }

        public override void Down()
        {
            Delete.Table("Theme");
        }
    }
}

