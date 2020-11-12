namespace Airport3.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightCity = c.String(),
                        FlightTime = c.DateTime(nullable: false),
                        PilotId = c.Int(nullable: false),
                        PlaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pilots", t => t.PilotId, cascadeDelete: true)
                .ForeignKey("dbo.Planes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PilotId)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.Pilots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelOfPlane = c.String(),
                        PassengerCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Flights", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Flights", "PilotId", "dbo.Pilots");
            DropIndex("dbo.Flights", new[] { "PlaneId" });
            DropIndex("dbo.Flights", new[] { "PilotId" });
            DropTable("dbo.Planes");
            DropTable("dbo.Pilots");
            DropTable("dbo.Flights");
        }
    }
}
