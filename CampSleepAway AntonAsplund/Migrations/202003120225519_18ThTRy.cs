namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18ThTRy : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cabins", "CounselorID", unique: true, name: "IX_CabinUniqueCounselor");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cabins", "IX_CabinUniqueCounselor");
        }
    }
}
