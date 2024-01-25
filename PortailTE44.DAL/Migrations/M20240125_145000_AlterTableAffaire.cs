using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240125_145000)]
    public class M20240125_145000_AlterTableAffaire : Migration
    {
        public override void Up()
        {
            Alter.Table("Affaire").AddColumn("Ville").AsString().Nullable();
            Alter.Table("Affaire").AddColumn("CodePostal").AsString().Nullable();
        }

        public override void Down()
        {
            if (Schema.Table("Affaire").Column("Ville").Exists())
                Delete.Column("Ville").FromTable("Affaire");

            if (Schema.Table("Affaire").Column("CodePostal").Exists())
                Delete.Column("CodePostal").FromTable("Affaire");
        }
    }
}
