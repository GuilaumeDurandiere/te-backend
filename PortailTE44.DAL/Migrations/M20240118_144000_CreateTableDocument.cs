using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_144000)]
    public class M20240118_144000_CreateTableDocument : Migration
    {
        public override void Up()
        {
            Create.Table("Document")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Nom").AsString().NotNullable()
                .WithColumn("Poids").AsInt32().NotNullable()
                .WithColumn("Decennal").AsBoolean().Nullable()
                .WithColumn("DossierId").AsInt32().Nullable().ForeignKey("Dossier", "Id")
                .WithColumn("RefTypeDocumentId").AsInt32().Nullable().ForeignKey("RefTypeDocument", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Document_DossierId_Dossier_Id").OnTable("Document");
            Delete.ForeignKey("FK_Document_RefTypeDocumentId_RefTypeDocument_Id").OnTable("Document");
            Delete.Table("Document");
        }
    }
}
