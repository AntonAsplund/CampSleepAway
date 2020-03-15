namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nuskadegå : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers");
            DropIndex("dbo.NextOfKinCampers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.NextOfKinCampers", new[] { "Camper_CamperId" });
            AddColumn("dbo.NextOfKins", "CamperID", c => c.Int(nullable: false));
            CreateIndex("dbo.NextOfKins", "CamperID");
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
            DropTable("dbo.NextOfKinCampers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NextOfKinCampers",
                c => new
                    {
                        NextOfKin_NextOfKinID = c.Int(nullable: false),
                        Camper_CamperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NextOfKin_NextOfKinID, t.Camper_CamperId });
            
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            DropColumn("dbo.NextOfKins", "CamperID");
            CreateIndex("dbo.NextOfKinCampers", "Camper_CamperId");
            CreateIndex("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID");
            AddForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers", "CamperId", cascadeDelete: true);
            AddForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins", "NextOfKinID", cascadeDelete: true);
        }
    }
}
