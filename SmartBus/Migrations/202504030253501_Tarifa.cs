namespace SmartBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarifa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rutas",
                c => new
                    {
                        RutaId = c.Int(nullable: false, identity: true),
                        Origen = c.String(),
                        Destino = c.String(),
                    })
                .PrimaryKey(t => t.RutaId);
            
            CreateTable(
                "dbo.Tarifas",
                c => new
                    {
                        TarifaId = c.Int(nullable: false, identity: true),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RutaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TarifaId)
                .ForeignKey("dbo.Rutas", t => t.RutaId, cascadeDelete: true)
                .Index(t => t.RutaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarifas", "RutaId", "dbo.Rutas");
            DropIndex("dbo.Tarifas", new[] { "RutaId" });
            DropTable("dbo.Tarifas");
            DropTable("dbo.Rutas");
        }
    }
}
