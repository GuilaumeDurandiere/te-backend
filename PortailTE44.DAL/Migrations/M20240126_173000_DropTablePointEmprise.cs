using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240126_173000)]
    public class M20240126_173000_DropTablePointEmprise : Migration
    {
        public override void Up()
        {
            if (Schema.Table("PointEmprise").Exists())
            {
                Delete.ForeignKey("FK_PointEmprise_AffaireId_Affaire_Id").OnTable("PointEmprise");
                Delete.Table("PointEmprise");
            }
        }

        public override void Down()
        {
            Create.Table("PointEmprise")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Ordre").AsInt32().NotNullable()
                .WithColumn("Latitude").AsDecimal().NotNullable()
                .WithColumn("Longitude").AsDecimal().NotNullable()
                .WithColumn("AffaireId").AsInt32().Nullable().ForeignKey("Affaire", "Id");
        }
    }
}
