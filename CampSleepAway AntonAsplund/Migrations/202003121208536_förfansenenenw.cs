namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class förfansenenenw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            DropPrimaryKey("dbo.Counselors");
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Counselors", "CounselorID");
            DropColumn("dbo.Cabins", "CounselorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int());
            DropIndex("dbo.Counselors", new[] { "CounselorID" });
            DropPrimaryKey("dbo.Counselors");
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Cabins", "CounselorID");
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
        }
    }
}
