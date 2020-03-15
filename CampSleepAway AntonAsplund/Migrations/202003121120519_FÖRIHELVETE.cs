namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FÖRIHELVETE : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Counselors", new[] { "CounselorID" });
            DropPrimaryKey("dbo.Counselors");
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int());
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Cabins", "CounselorID");
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            DropPrimaryKey("dbo.Counselors");
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false));
            DropColumn("dbo.Cabins", "CounselorID");
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Counselors", "CounselorID");
        }
    }
}
