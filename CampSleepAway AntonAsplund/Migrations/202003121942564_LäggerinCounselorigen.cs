namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LäggerinCounselorigen : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int());
            CreateIndex("dbo.Cabins", "CounselorID");
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.Counselors", "IX_CounselorUniqueSSN");
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            DropColumn("dbo.Cabins", "CounselorID");
            DropTable("dbo.Counselors");
        }
    }
}
