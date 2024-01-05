using FluentMigrator;

namespace PortailTE44.DAL.Migrations
{
	[Migration(20240104_140000)]
	public class M20240104_140000_NullableColumn : Migration
	{
        public override void Up()
        {
            Alter.Table("Theme")
                .AlterColumn("Description").AsString().Nullable();
            Alter.Table("SousTheme")
                .AlterColumn("LienExterne").AsString().Nullable()
                .AlterColumn("Description").AsString().Nullable()
                .AlterColumn("DemandeSimple").AsBoolean().NotNullable()
                .AddColumn("Icone").AsString().NotNullable()
                .AddColumn("AccessibleATous").AsBoolean().NotNullable()
                .AddColumn("HorsTravaux").AsBoolean().NotNullable()
                .AddColumn("Couleur").AsString().NotNullable()
                .AddColumn("WorkflowTravauxSimplifie").AsBoolean().Nullable()
                .AddColumn("WorkflowId").AsInt32().Nullable();
            Delete.Column("TypeWorkflow").FromTable("SousTheme");
            Delete.Column("Accessible").FromTable("SousTheme");

        }

        public override void Down()
        {
            Alter.Table("Theme")
              .AlterColumn("Description").AsString().NotNullable();
            Alter.Table("SousTheme")
                .AlterColumn("LienExterne").AsString().NotNullable()
                .AlterColumn("Description").AsString().NotNullable()
                .AlterColumn("DemandeSimple").AsBoolean().Nullable()
                .AddColumn("Accessible").AsBoolean().NotNullable()
                .AddColumn("TypeWorkflow").AsString().NotNullable();
            Delete.Column("Icone").FromTable("SousTheme");
            Delete.Column("AccessibleATous").FromTable("SousTheme");
            Delete.Column("HorsTravaux").FromTable("SousTheme");
            Delete.Column("Couleur").FromTable("SousTheme");
            Delete.Column("WorkflowTravauxSimplifie").FromTable("SousTheme");
            Delete.Column("WorkflowId").FromTable("SousTheme");
        }
    }
}

