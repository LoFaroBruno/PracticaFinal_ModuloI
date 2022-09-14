namespace AFIPPersonasWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodActividadCodigoToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CodActividads", "Codigo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CodActividads", "Codigo", c => c.Int(nullable: false));
        }
    }
}
