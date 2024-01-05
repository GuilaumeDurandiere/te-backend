using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240105_103000)]
    public class M20240105_103000_CreateTableRefProfil : Migration
    {
        public override void Up()
        {
            Create.Table("RefProfil")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Code").AsString().NotNullable()
                .WithColumn("Libelle").AsString().NotNullable();

            Insert.IntoTable("RefProfil").Row(new { Id = 1, Code = "ADMIN", Libelle = "Administrateur" });
            Insert.IntoTable("RefProfil").Row(new { Id = 2, Code = "REFERENT_OFFRE", Libelle = "Référent offre et communication" });
            Insert.IntoTable("RefProfil").Row(new { Id = 3, Code = "INTERVENANT_TE44", Libelle = "Intervenant TE44" });
            Insert.IntoTable("RefProfil").Row(new { Id = 4, Code = "RESPONSABLE_COLLECTIVITE", Libelle = "Responsable collectivité" });
            Insert.IntoTable("RefProfil").Row(new { Id = 5, Code = "INTERVENANT_COLLECTIVITE", Libelle = "Intervenant collectivité" });
        }

        public override void Down()
        {
            Delete.Table("RefProfil");
        }
    }
}
