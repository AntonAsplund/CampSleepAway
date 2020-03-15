namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ifene3nf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cabins", "CounselorID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cabins", "CounselorID");
        }
    }
}
