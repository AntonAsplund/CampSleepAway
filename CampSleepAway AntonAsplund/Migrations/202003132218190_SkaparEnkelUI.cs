namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SkaparEnkelUI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CamperHistories",
                c => new
                    {
                        CamperHistoryID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SocialSecurityNumber = c.Int(nullable: false),
                        CabinID = c.Int(),
                        CamperID = c.Int(nullable: false),
                        CheckIn = c.DateTime(),
                        CheckOut = c.DateTime(),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CamperHistoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CamperHistories");
        }
    }
}
