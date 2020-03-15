namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        CabinID = c.Int(nullable: false, identity: true),
                        CabinNickName = c.String(),
                        Counselor_CounselorID = c.Int(),
                    })
                .PrimaryKey(t => t.CabinID)
                .ForeignKey("dbo.Counselors", t => t.Counselor_CounselorID)
                .Index(t => t.Counselor_CounselorID);
            
            CreateTable(
                "dbo.Campers",
                c => new
                    {
                        CamperId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                        Cabin_CabinID = c.Int(),
                    })
                .PrimaryKey(t => t.CamperId)
                .ForeignKey("dbo.Cabins", t => t.Cabin_CabinID)
                .Index(t => t.SocialSecurityNumber, unique: true, name: "IX_CamperUniqueSSN")
                .Index(t => t.Cabin_CabinID);
            
            CreateTable(
                "dbo.NextOfKins",
                c => new
                    {
                        NextOfKinID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        SocialSecurtyNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NextOfKinID)
                .Index(t => t.SocialSecurtyNumber, unique: true, name: "IX_CounselorUniqueSSN");
            
            CreateTable(
                "dbo.Counselors",
                c => new
                    {
                        CounselorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastNAme = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CounselorID)
                .Index(t => t.SocialSecurityNumber, unique: true, name: "IX_CounselorUniqueSSN");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cabins", "Counselor_CounselorID", "dbo.Counselors");
            DropForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.NextOfKinCampers", new[] { "Camper_CamperId" });
            DropIndex("dbo.NextOfKinCampers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.Counselors", "IX_CounselorUniqueSSN");
            DropIndex("dbo.NextOfKins", "IX_CounselorUniqueSSN");
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            DropIndex("dbo.Campers", "IX_CamperUniqueSSN");
            DropIndex("dbo.Cabins", new[] { "Counselor_CounselorID" });
            DropTable("dbo.NextOfKinCampers");
            DropTable("dbo.Counselors");
            DropTable("dbo.NextOfKins");
            DropTable("dbo.Campers");
            DropTable("dbo.Cabins");
        }
    }
}
