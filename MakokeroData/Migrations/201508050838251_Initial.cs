namespace MakokeroData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventOwners",
                c => new
                    {
                        EventOwnerId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        ClientName = c.String(nullable: false, maxLength: 50),
                        CompanyName = c.String(maxLength: 50),
                        PositionTitle = c.String(maxLength: 50),
                        Telephone = c.String(maxLength: 50),
                        MobilePhone = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EventOwnerId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventOwnerId = c.Int(nullable: false),
                        StyleOfFunction = c.Int(nullable: false),
                        PaymentOption = c.Int(nullable: false),
                        NumberOfGuests = c.Int(nullable: false),
                        SpecialRequirements = c.String(maxLength: 250),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        SetupTime = c.Time(nullable: false, precision: 7),
                        PackupTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventOwners", t => t.EventOwnerId)
                .Index(t => t.EventOwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventOwnerId", "dbo.EventOwners");
            DropIndex("dbo.Events", new[] { "EventOwnerId" });
            DropTable("dbo.Events");
            DropTable("dbo.EventOwners");
        }
    }
}
