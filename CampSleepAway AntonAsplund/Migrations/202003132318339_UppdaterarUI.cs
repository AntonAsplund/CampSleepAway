namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdaterarUI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CamperHistories", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.CamperHistories", "CheckIn");
            DropColumn("dbo.CamperHistories", "CheckOut");
            DropColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStampCheckIn");
            DropColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStampCheckOut");
            DropColumn("dbo.NextOfKinHistories", "TimeStampRemoved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NextOfKinHistories", "TimeStampRemoved", c => c.DateTime());
            AddColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStampCheckOut", c => c.DateTime());
            AddColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStampCheckIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.CamperHistories", "CheckOut", c => c.DateTime());
            AddColumn("dbo.CamperHistories", "CheckIn", c => c.DateTime());
            DropColumn("dbo.NextOfKinCheckInCheckOuts", "TimeStamp");
            DropColumn("dbo.CamperHistories", "IsActive");
        }
    }
}
