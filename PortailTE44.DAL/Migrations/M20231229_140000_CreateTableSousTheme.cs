using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231229_140000)]
    public class M20231229_140000_CreateTableSousTheme : Migration
    {
        public override void Up()
        {
            Create.Table("SousTheme")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("LienExterne").AsString().Nullable()
                .WithColumn("MailReferent").AsString().NotNullable()
                .WithColumn("DemandeSimple").AsBoolean().NotNullable()
                .WithColumn("AccessibleATous").AsBoolean().NotNullable()
                .WithColumn("HorsTravaux").AsBoolean().NotNullable()
                .WithColumn("Couleur").AsString().NotNullable()
                .WithColumn("WorkflowTravauxSimplifie").AsBoolean().NotNullable()
                .WithColumn("ThemeId").AsInt32().NotNullable().ForeignKey("Theme", "Id")
                .WithColumn("WorkflowId").AsInt32().NotNullable().ForeignKey("Workflow", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_SousTheme_WorkflowId_Workflow_Id").OnTable("SousTheme");
            Delete.ForeignKey("FK_SousTheme_ThemeId_Theme_Id").OnTable("SousTheme");
            Delete.Table("SousTheme");
        }
    }
}

