using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_135000)]
    public class M20240118_135000_CreateTableAffaire : Migration
    {
        public override void Up()
        {
            Create.Table("Affaire")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("NumAffaire").AsString().NotNullable()
                .WithColumn("DateCreation").AsDateTime().NotNullable()
                .WithColumn("DateMiseEnService").AsDateTime().Nullable()
                .WithColumn("Adresse").AsString().Nullable()
                .WithColumn("NumeroVoie").AsString().Nullable()
                .WithColumn("Site").AsString().Nullable()
                .WithColumn("DateValidationFacture").AsDateTime().Nullable()
                .WithColumn("Description").AsString(Int32.MaxValue).Nullable()
                .WithColumn("Commentaire").AsString(Int32.MaxValue).Nullable()
                .WithColumn("DateCloture").AsDateTime().Nullable()
                .WithColumn("HorsTravaux").AsBoolean().NotNullable()
                .WithColumn("DemandeurNom").AsString().NotNullable()
                .WithColumn("DemandeurPrenom").AsString().NotNullable()
                .WithColumn("DemandeurMail").AsString().NotNullable()
                .WithColumn("DemandeurPoste").AsString().NotNullable()
                .WithColumn("ContactTechniqueId").AsInt32().Nullable().ForeignKey("Utilisateur", "Id")
                .WithColumn("ContactAdministratif").AsInt32().Nullable().ForeignKey("Utilisateur", "Id")
                .WithColumn("SousThemeId").AsInt32().Nullable().ForeignKey("SousTheme", "Id")
                .WithColumn("CollectiviteId").AsInt32().Nullable().ForeignKey("Collectivite", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Affaire_CollectiviteId_Collectivite_Id").OnTable("Affaire");
            Delete.ForeignKey("FK_Affaire_ContactAdministratif_Utilisateur_Id").OnTable("Affaire");
            Delete.ForeignKey("FK_Affaire_ContactTechniqueId_Utilisateur_Id").OnTable("Affaire");
            Delete.ForeignKey("FK_Affaire_SousThemeId_SousTheme_Id").OnTable("Affaire");
            Delete.Table("Affaire");
        }
    }
}
