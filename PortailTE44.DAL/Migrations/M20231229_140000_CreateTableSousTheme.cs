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
                .WithColumn("LienExterne").AsString().Nullable()
                .WithColumn("DemandeSimple").AsBoolean().Nullable()
                .WithColumn("TypeWorkflow").AsString().Nullable()
                .WithColumn("Accessible").AsBoolean().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("MailReferent").AsString().NotNullable()
                .WithColumn("ThemeId").AsInt32().NotNullable().ForeignKey("Theme", "Id");
        }
    }
}

