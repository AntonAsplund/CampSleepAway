namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Komigen : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cabins", "IX_CounselorInOnlyOneCabin");
            CreateIndex("dbo.Cabins", "CounselorID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cabins", new[] { "CounselorID" });
            CreateIndex("dbo.Cabins", "CounselorID", unique: true, name: "IX_CounselorInOnlyOneCabin");
        }
    }
}
