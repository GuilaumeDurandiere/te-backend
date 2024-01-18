using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_145500)]
    public class M20240118_145500_CreateTableInformationFinanciere : Migration
    {
        public override void Up()
        {
            Create.Table("InformationFinanciere")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("PrevisionnelCoutDossier").AsInt32().Nullable()
                .WithColumn("PrevisionnelParticipationDemandeur").AsInt32().Nullable()
                .WithColumn("PrevisionnelAcompteDemande").AsInt32().Nullable()
                .WithColumn("PrevisionnelSolde").AsInt32().Nullable()
                .WithColumn("ReelCoutDossier").AsInt32().Nullable()
                .WithColumn("ReelParticipationDemandeur").AsInt32().Nullable()
                .WithColumn("ReelAcompteDemande").AsInt32().Nullable()
                .WithColumn("ReelSolde").AsInt32().Nullable()
                .WithColumn("AffaireId").AsInt32().Nullable().ForeignKey("Affaire", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_InformationFinanciere_AffaireId_Affaire_Id").OnTable("InformationFinanciere");
            Delete.Table("InformationFinanciere");
        }
    }
}
