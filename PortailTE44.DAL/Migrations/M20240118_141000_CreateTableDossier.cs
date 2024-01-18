using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_141000)]
    public class M20240118_141000_CreateTableDossier : Migration
    {
        public override void Up()
        {
            Create.Table("Dossier")
               .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
               .WithColumn("SydenetId").AsString().Nullable()
               .WithColumn("Libelle").AsString().Nullable()
               .WithColumn("DateCreation").AsDateTime().NotNullable()
               .WithColumn("Virtuel").AsBoolean().NotNullable()
               .WithColumn("AffaireId").AsInt32().Nullable().ForeignKey("Affaire", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Dossier_AffaireId_Affaire_Id").OnTable("Dossier");
            Delete.Table("Dossier");
        }
    }
}
