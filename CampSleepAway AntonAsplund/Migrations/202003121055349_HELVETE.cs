namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HELVETE : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cabins", "CounselorID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int(nullable: false));
        }
    }
}
