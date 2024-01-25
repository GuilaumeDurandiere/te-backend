using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240124_145500)]
    public class M20240124_100000_CreateTablePreferenceUtilisateurAffichageAffaire : Migration
    {
        public override void Up()
        {
            Create.Table("PreferenceUtilisateurAffichageAffaire")
                .WithColumn("UtilisateurId").AsInt32().NotNullable().ForeignKey("Utilisateur", "Id")
                .WithColumn("Communautes").AsString().Nullable()
                .WithColumn("Communes").AsString().Nullable()
                .WithColumn("Themes").AsString().NotNullable()
                .WithColumn("SousThemes").AsString().NotNullable()
                .WithColumn("Responsables").AsString().Nullable()
                .WithColumn("Statut").AsString().NotNullable()
                .WithColumn("AvantLe").AsDate().Nullable()
                .WithColumn("ApresLe").AsDate().Nullable()
                .WithColumn("NumeroAffaire").AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_PreferenceUtilisateurAffichageAffaire_UtilisateurId_Utilisateur_Id").OnTable("PreferenceUtilisateurAffichageAffaire");
            Delete.Table("PreferenceUtilisateurAffichageAffaire");
        }
    }
}