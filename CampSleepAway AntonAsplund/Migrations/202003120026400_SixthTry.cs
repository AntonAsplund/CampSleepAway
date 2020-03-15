namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthTry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cabins", "Camper_CamperId", c => c.Int());
            AddColumn("dbo.Campers", "NextOfKin_NextOfKinID", c => c.Int());
            CreateIndex("dbo.Cabins", "Camper_CamperId");
            CreateIndex("dbo.Campers", "NextOfKin_NextOfKinID");
            AddForeignKey("dbo.Campers", "NextOfKin_NextOfKinID", "dbo.NextOfKins", "NextOfKinID");
            AddForeignKey("dbo.Cabins", "Camper_CamperId", "dbo.Campers", "CamperId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cabins", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropIndex("dbo.Campers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.Cabins", new[] { "Camper_CamperId" });
            DropColumn("dbo.Campers", "NextOfKin_NextOfKinID");
            DropColumn("dbo.Cabins", "Camper_CamperId");
        }
    }
}
