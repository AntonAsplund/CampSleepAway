namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixadeCounselor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            CreateTable(
                "dbo.CabinsCounselors",
                c => new
                    {
                        CabinsCounselorID = c.Int(nullable: false, identity: true),
                        CounselorID = c.Int(nullable: false),
                        CabinID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CabinsCounselorID)
                .ForeignKey("dbo.Cabins", t => t.CabinID, cascadeDelete: true)
                .ForeignKey("dbo.Counselors", t => t.CounselorID, cascadeDelete: true)
                .Index(t => t.CounselorID, unique: true, name: "UIX_OneSingleCounselor")
                .Index(t => t.CabinID, unique: true, name: "UIX_OneSingleCabin");
            
            DropColumn("dbo.Cabins", "CounselorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int());
            DropForeignKey("dbo.CabinsCounselors", "CounselorID", "dbo.Counselors");
            DropForeignKey("dbo.CabinsCounselors", "CabinID", "dbo.Cabins");
            DropIndex("dbo.CabinsCounselors", "UIX_OneSingleCabin");
            DropIndex("dbo.CabinsCounselors", "UIX_OneSingleCounselor");
            DropTable("dbo.CabinsCounselors");
            CreateIndex("dbo.Cabins", "CounselorID");
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
        }
    }
}
