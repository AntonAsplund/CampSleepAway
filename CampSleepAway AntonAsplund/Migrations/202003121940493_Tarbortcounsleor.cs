namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarbortcounsleor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors");
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            DropIndex("dbo.Counselors", "IX_CounselorUniqueSSN");
            DropColumn("dbo.Cabins", "CounselorID");
            DropTable("dbo.Counselors");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.CounselorID);
            
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int());
            CreateIndex("dbo.Counselors", "SocialSecurityNumber", unique: true, name: "IX_CounselorUniqueSSN");
            CreateIndex("dbo.Cabins", "CounselorID");
            AddForeignKey("dbo.Cabins", "CounselorID", "dbo.Counselors", "CounselorID");
        }
    }
}
