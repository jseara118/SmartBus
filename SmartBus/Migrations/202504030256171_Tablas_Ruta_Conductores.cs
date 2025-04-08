namespace SmartBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablas_Ruta_Conductores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conductors",
                c => new
                    {
                        ConductorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Licencia = c.String(),
                    })
                .PrimaryKey(t => t.ConductorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conductors");
        }
    }
}
