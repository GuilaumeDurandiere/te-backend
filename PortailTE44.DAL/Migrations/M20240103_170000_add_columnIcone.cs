using System;
using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
	[Migration(20240103_170000)]
	public class M20240103_170000_add_columnIcone : Migration
	{
		public M20240103_170000_add_columnIcone()
		{
		}

        public override void Down()
        {
            Delete.Column("Icone").FromTable("Theme");
          
        }

        public override void Up()
        {
            Alter.Table("Theme")
                .AddColumn("Icone").AsString().NotNullable();
        }
    }
}

