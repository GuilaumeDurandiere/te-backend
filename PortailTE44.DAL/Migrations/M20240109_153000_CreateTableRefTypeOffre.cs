using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240109_153000)]
    public class M20240109_153000_CreateTableRefTypeOffre : Migration
    {
        public override void Up()
        {
            Create.Table("RefTypeOffre")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Code").AsString().NotNullable()
                .WithColumn("Libelle").AsString().NotNullable();

            Insert.IntoTable("RefTypeOffre").Row(new { Id = 1, Code = "FORMULAIRE_SIMPLIFIE", Libelle = "Formulaire simplifié" });
            Insert.IntoTable("RefTypeOffre").Row(new { Id = 2, Code = "LIEN_EXTERNE", Libelle = "Lien externe" });
            Insert.IntoTable("RefTypeOffre").Row(new { Id = 3, Code = "DEMANDE_HORS_TRAVAUX", Libelle = "Demande hors travaux" });
            Insert.IntoTable("RefTypeOffre").Row(new { Id = 4, Code = "DEMANDE_TRAVAUX", Libelle = "Demande travaux" });
        }

        public override void Down()
        {
            Delete.Table("RefTypeOffre");
        }
    }
}
