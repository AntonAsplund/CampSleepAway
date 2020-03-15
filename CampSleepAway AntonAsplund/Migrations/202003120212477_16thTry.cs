namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16thTry : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Counselors", new[] { "Cabin_CabinID" });
            DropPrimaryKey("dbo.Counselors");
            DropColumn("dbo.Counselors", "CounselorID");
            RenameColumn(table: "dbo.Counselors", name: "Cabin_CabinID", newName: "CounselorID");
            
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Counselors", "CounselorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Counselors", new[] { "CounselorID" });
            DropPrimaryKey("dbo.Counselors");
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int());
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Cabins", "CounselorID");
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            RenameColumn(table: "dbo.Counselors", name: "CounselorID", newName: "Cabin_CabinID");
            AddColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Counselors", "Cabin_CabinID");
        }
    }
}
