namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UppdateratTableHanteringen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CabinsCounselors", "CabinID", "dbo.Cabins");
            DropForeignKey("dbo.CabinsCounselors", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.CabinsCounselors", "UIX_OneSingleCounselor");
            DropIndex("dbo.CabinsCounselors", "UIX_OneSingleCabin");
            AddColumn("dbo.Cabins", "Counselor_CounselorID", c => c.Int());
            AddColumn("dbo.Counselors", "Cabin_CabinID", c => c.Int());
            CreateIndex("dbo.Cabins", "Counselor_CounselorID");
            CreateIndex("dbo.Counselors", "Cabin_CabinID");
            AddForeignKey("dbo.Counselors", "Cabin_CabinID", "dbo.Cabins", "CabinID");
            AddForeignKey("dbo.Cabins", "Counselor_CounselorID", "dbo.Counselors", "CounselorID");
            DropTable("dbo.CabinsCounselors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CabinsCounselors",
                c => new
                    {
                        CabinsCounselorID = c.Int(nullable: false, identity: true),
                        CounselorID = c.Int(nullable: false),
                        CabinID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CabinsCounselorID);
            
            DropForeignKey("dbo.Cabins", "Counselor_CounselorID", "dbo.Counselors");
            DropForeignKey("dbo.Counselors", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.Counselors", new[] { "Cabin_CabinID" });
            DropIndex("dbo.Cabins", new[] { "Counselor_CounselorID" });
            DropColumn("dbo.Counselors", "Cabin_CabinID");
            DropColumn("dbo.Cabins", "Counselor_CounselorID");
            CreateIndex("dbo.CabinsCounselors", "CabinID", unique: true, name: "UIX_OneSingleCabin");
            CreateIndex("dbo.CabinsCounselors", "CounselorID", unique: true, name: "UIX_OneSingleCounselor");
            AddForeignKey("dbo.CabinsCounselors", "CounselorID", "dbo.Counselors", "CounselorID", cascadeDelete: true);
            AddForeignKey("dbo.CabinsCounselors", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
        }
    }
}
