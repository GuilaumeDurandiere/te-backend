using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
    [Migration(20240118_142000)]
    public class M20240118_142000_CreateTableRefTypeDocument : Migration
    {
        public override void Up()
        {
            Create.Table("RefTypeDocument")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("Code").AsString().NotNullable();

            Insert.IntoTable("RefTypeDocument").Row(new { Id = 1, Code = "WORD" });
            Insert.IntoTable("RefTypeDocument").Row(new { Id = 2, Code = "EXCEL" });
            Insert.IntoTable("RefTypeDocument").Row(new { Id = 3, Code = "POWERPOINT" });
            Insert.IntoTable("RefTypeDocument").Row(new { Id = 4, Code = "PDF" });
            Insert.IntoTable("RefTypeDocument").Row(new { Id = 5, Code = "IMAGE" });
        }

        public override void Down()
        {
            Delete.Table("RefTypeDocument");
        }
    }
}
