using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_145000)]
    public class M20240118_145000_CreateTablePointEmprise : Migration
    {
        public override void Up()
        {
            Create.Table("PointEmprise")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Ordre").AsInt32().NotNullable()
                .WithColumn("Latitude").AsDecimal().NotNullable()
                .WithColumn("Longitude").AsDecimal().NotNullable()
                .WithColumn("AffaireId").AsInt32().Nullable().ForeignKey("Affaire", "Id");
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_PointEmprise_AffaireId_Affaire_Id").OnTable("PointEmprise");
            Delete.Table("PointEmprise");
        }
    }
}
