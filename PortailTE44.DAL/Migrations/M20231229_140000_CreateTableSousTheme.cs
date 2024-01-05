using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231229_140000)]
    public class M20231229_140000_CreateTableSousTheme : Migration
    {
        public override void Down()
        {
            Delete.Table("SousTheme");
        }

        public override void Up()
        {
            Create.Table("SousTheme")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("LienExterne").AsString()
                .WithColumn("DemandeSimple").AsBoolean()
                .WithColumn("TypeWorkflow").AsString()
                .WithColumn("Accessible").AsBoolean()
                .WithColumn("Description").AsString()
                .WithColumn("MailReferent").AsString().NotNullable()
                .WithColumn("ThemeId").AsInt32().NotNullable().ForeignKey("Theme", "Id");
        }
    }
}

