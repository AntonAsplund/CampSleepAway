namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingAfterDinner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            DropIndex("dbo.NextOfKins", new[] { "Camper_CamperId" });
            DropIndex("dbo.Counselors", new[] { "CounselorID" });
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            DropPrimaryKey("dbo.Counselors");
            CreateTable(
                "dbo.NextOfKinCampers",
                c => new
                    {
                        NextOfKin_NextOfKinID = c.Int(nullable: false),
                        Camper_CamperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NextOfKin_NextOfKinID, t.Camper_CamperId })
                .ForeignKey("dbo.NextOfKins", t => t.NextOfKin_NextOfKinID, cascadeDelete: true)
                .ForeignKey("dbo.Campers", t => t.Camper_CamperId, cascadeDelete: true)
                .Index(t => t.NextOfKin_NextOfKinID)
                .Index(t => t.Camper_CamperId);
            
            AddColumn("dbo.Cabins", "CabinNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "FreeCamperBunks", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "TotalCamperBunks", c => c.Int(nullable: false));
            AlterColumn("dbo.Cabins", "CounselorID", c => c.Int());
            AlterColumn("dbo.Campers", "CabinID", c => c.Int(nullable: false));
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.Cabins", "CounselorID", unique: true, name: "IX_CounselorInOnlyOneCabin");
            CreateIndex("dbo.Campers", "CabinID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
            DropColumn("dbo.Cabins", "CamperID");
            DropColumn("dbo.Campers", "NextOFKinID");
            DropColumn("dbo.NextOfKins", "Camper_CamperId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NextOfKins", "Camper_CamperId", c => c.Int());
            AddColumn("dbo.Campers", "NextOFKinID", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "CamperID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropIndex("dbo.NextOfKinCampers", new[] { "Camper_CamperId" });
            DropIndex("dbo.NextOfKinCampers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.Campers", new[] { "CabinID" });
            DropIndex("dbo.Cabins", "IX_CounselorInOnlyOneCabin");
            DropPrimaryKey("dbo.Counselors");
            AlterColumn("dbo.Counselors", "CounselorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Campers", "CabinID", c => c.Int());
            AlterColumn("dbo.Cabins", "CounselorID", c => c.Int(nullable: false));
            DropColumn("dbo.Cabins", "TotalCamperBunks");
            DropColumn("dbo.Cabins", "FreeCamperBunks");
            DropColumn("dbo.Cabins", "CabinNumber");
            DropTable("dbo.NextOfKinCampers");
            AddPrimaryKey("dbo.Counselors", "CounselorID");
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            CreateIndex("dbo.Counselors", "CounselorID");
            CreateIndex("dbo.NextOfKins", "Camper_CamperId");
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
            AddForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers", "CamperId");
        }
    }
}
