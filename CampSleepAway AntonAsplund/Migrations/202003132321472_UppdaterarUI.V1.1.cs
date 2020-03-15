namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdaterarUIV11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NextOfKinHistories", "TimeStamp", c => c.DateTime(nullable: false));
            DropColumn("dbo.NextOfKinHistories", "TimeStampAdded");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NextOfKinHistories", "TimeStampAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.NextOfKinHistories", "TimeStamp");
        }
    }
}
