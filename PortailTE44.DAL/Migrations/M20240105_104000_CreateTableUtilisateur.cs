using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240105_104000)]
    public class M20240105_104000_CreateTableUtilisateur : Migration
    {
        public override void Up()
        {
            Create.Table("Utilisateur")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Email").AsString().NotNullable().Unique()
                .WithColumn("Nom").AsString().NotNullable()
                .WithColumn("Prenom").AsString().NotNullable()
                .WithColumn("Poste").AsString().NotNullable()
                .WithColumn("RefProfilId").AsInt32().NotNullable().ForeignKey("RefProfil", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Utilisateur_RefProfilId_RefProfil_Id").OnTable("Utilisateur");
            Delete.Table("Utilisateur");
        }
    }
}
