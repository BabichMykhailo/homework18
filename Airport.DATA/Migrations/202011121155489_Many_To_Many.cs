namespace Airport.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many_To_Many : DbMigration
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

            string query = "DECLARE @count INT, @c INT" + "\n" + "SET @count=(SELECT MAX(Id) FROM Flights);" + "\n" + "SET @c=1;" + "\n" + "WHILE(@c<=@count)" + "\n"
                + "BEGIN" + "\n" + "IF EXISTS(SELECT Id FROM Flights WHERE Id=@c)" + "\n" + "BEGIN" + "\n"
                + "INSERT INTO FlightPilots(Flight_Id, Pilot_Id) VALUES((SELECT Id FROM Flights WHERE Id = @c), (SELECT PilotId FROM Flights WHERE Id = @c))" + "\n"
                + "END" + "\n" + "SET @c = @c + 1" + "\n" + "END";
            Sql(query);
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
