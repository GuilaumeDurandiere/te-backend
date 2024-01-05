using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240105_105000)]
    public class M20240105_105000_CreateTableUtilisateurCollectivite : Migration
    {
        public override void Up()
        {
            Create.Table("UtilisateurCollectivite")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("UtilisateurId").AsInt32().NotNullable().ForeignKey("Utilisateur", "Id")
                .WithColumn("CollectiviteId").AsInt32().NotNullable().ForeignKey("Collectivite", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_UtilisateurCollectivite_UtilisateurId_Utilisateur_Id").OnTable("UtilisateurCollectivite");
            Delete.ForeignKey("FK_UtilisateurCollectivite_CollectiviteId_Collectivite_Id").OnTable("UtilisateurCollectivite");
            Delete.Table("UtilisateurCollectivite");
        }
    }
}
