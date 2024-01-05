using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20231215_170000)]
    public class M20231215_170000_CreateTableSousEtape : Migration
    {
        public override void Up()
        {
            Create.Table("SousEtape")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Libelle").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("EtapeId").AsInt32().NotNullable().ForeignKey("Etape", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_SousEtape_EtapeId_Etape_Id").OnTable("SousEtape");
            Delete.Table("SousEtape");
        }
    }
}
