namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            DropIndex("dbo.NextOfKinCampers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.NextOfKinCampers", new[] { "Camper_CamperId" });
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            AddColumn("dbo.NextOfKins", "CamperID", c => c.Int(nullable: false));
            AlterColumn("dbo.Campers", "CabinID", c => c.Int(nullable: false));
            CreateIndex("dbo.Campers", "CabinID");
            CreateIndex("dbo.NextOfKins", "CamperID");
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
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
            
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            DropIndex("dbo.Campers", new[] { "CabinID" });
            AlterColumn("dbo.Campers", "CabinID", c => c.Int());
            DropColumn("dbo.NextOfKins", "CamperID");
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            CreateIndex("dbo.NextOfKinCampers", "Camper_CamperId");
            CreateIndex("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID");
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
            AddForeignKey("dbo.NextOfKinCampers", "Camper_CamperId", "dbo.Campers", "CamperId", cascadeDelete: true);
            AddForeignKey("dbo.NextOfKinCampers", "NextOfKin_NextOfKinID", "dbo.NextOfKins", "NextOfKinID", cascadeDelete: true);
        }
    }
}
