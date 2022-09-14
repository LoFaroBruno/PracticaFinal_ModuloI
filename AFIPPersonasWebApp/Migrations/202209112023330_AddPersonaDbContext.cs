namespace AFIPPersonasWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonaDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CodActividadId = c.Int(nullable: false),
                        ClaveTributaria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CodActividads", t => t.CodActividadId, cascadeDelete: true)
                .Index(t => t.CodActividadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "CodActividadId", "dbo.CodActividads");
            DropIndex("dbo.Personas", new[] { "CodActividadId" });
            DropTable("dbo.Personas");
        }
    }
}
