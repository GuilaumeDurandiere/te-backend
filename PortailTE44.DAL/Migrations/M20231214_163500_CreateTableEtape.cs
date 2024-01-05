using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231214_163500)]
    public class M20231214_163500_CreateTableEtape : Migration
    {
        public override void Up()
        {
            Create.Table("Etape")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Statut").AsString().NotNullable()
                .WithColumn("WorkflowId").AsInt32().NotNullable().ForeignKey("Workflow", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Etape_WorkflowId_Workflow_Id").OnTable("Etape");
            Delete.Table("Etape");
        }
    }
}
