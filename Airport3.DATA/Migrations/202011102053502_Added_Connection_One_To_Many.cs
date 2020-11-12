namespace Airport3.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Connection_One_To_Many : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Flights", "PilotId", "dbo.Pilots");
            DropIndex("dbo.Flights", new[] { "PilotId" });
            CreateTable(
                "dbo.FlightPilots",
                c => new
                    {
                        Flight_Id = c.Int(nullable: false),
                        Pilot_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Flight_Id, t.Pilot_Id })
                .ForeignKey("dbo.Flights", t => t.Flight_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pilots", t => t.Pilot_Id, cascadeDelete: true)
                .Index(t => t.Flight_Id)
                .Index(t => t.Pilot_Id);
            
            DropColumn("dbo.Flights", "PilotId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "PilotId", c => c.Int(nullable: false));
            DropForeignKey("dbo.FlightPilots", "Pilot_Id", "dbo.Pilots");
            DropForeignKey("dbo.FlightPilots", "Flight_Id", "dbo.Flights");
            DropIndex("dbo.FlightPilots", new[] { "Pilot_Id" });
            DropIndex("dbo.FlightPilots", new[] { "Flight_Id" });
            DropTable("dbo.FlightPilots");
            CreateIndex("dbo.Flights", "PilotId");
            AddForeignKey("dbo.Flights", "PilotId", "dbo.Pilots", "Id", cascadeDelete: true);
        }
    }
}
