namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CounselorHistories",
                c => new
                    {
                        CounselorHistoryID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                        CounselorID = c.Int(nullable: false),
                        CabinID = c.Int(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CounselorHistoryID);
            
            CreateTable(
                "dbo.NextOfKinCheckInCheckOuts",
                c => new
                    {
                        NextOfKinCheckInCheckOutID = c.Int(nullable: false, identity: true),
                        CamperID = c.Int(nullable: false),
                        NextOfKinID = c.Int(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        TimeStampCheckIn = c.DateTime(nullable: false),
                        TimeStampCheckOut = c.DateTime(),
                    })
                .PrimaryKey(t => t.NextOfKinCheckInCheckOutID);
            
            CreateTable(
                "dbo.NextOfKinHistories",
                c => new
                    {
                        NextOfKinHistoryID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                        CamperID = c.Int(nullable: false),
                        NextOfKinID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        TimeStampAdded = c.DateTime(nullable: false),
                        TimeStampRemoved = c.DateTime(),
                    })
                .PrimaryKey(t => t.NextOfKinHistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NextOfKinHistories");
            DropTable("dbo.NextOfKinCheckInCheckOuts");
            DropTable("dbo.CounselorHistories");
        }
    }
}
