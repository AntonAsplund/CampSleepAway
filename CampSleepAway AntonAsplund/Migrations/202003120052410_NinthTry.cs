namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campers", "NextOfKin_NextOfKinID", "dbo.NextOfKins");
            DropForeignKey("dbo.Cabins", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers");
            DropIndex("dbo.Cabins", new[] { "Camper_CamperId" });
            DropIndex("dbo.Campers", new[] { "NextOfKin_NextOfKinID" });
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            DropIndex("dbo.NextOfKins", new[] { "Camper_CamperId" });
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            RenameColumn(table: "dbo.NextOfKins", name: "Camper_CamperId", newName: "CamperID");
            AlterColumn("dbo.Campers", "CabinID", c => c.Int(nullable: false));
            AlterColumn("dbo.NextOfKins", "CamperID", c => c.Int(nullable: false));
            CreateIndex("dbo.Campers", "CabinID");
            CreateIndex("dbo.NextOfKins", "CamperID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
            DropColumn("dbo.Cabins", "Camper_CamperId");
            DropColumn("dbo.Campers", "NextOfKin_NextOfKinID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campers", "NextOfKin_NextOfKinID", c => c.Int());
            AddColumn("dbo.Cabins", "Camper_CamperId", c => c.Int());
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            DropIndex("dbo.Campers", new[] { "CabinID" });
            AlterColumn("dbo.NextOfKins", "CamperID", c => c.Int());
            AlterColumn("dbo.Campers", "CabinID", c => c.Int());
            RenameColumn(table: "dbo.NextOfKins", name: "CamperID", newName: "Camper_CamperId");
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            CreateIndex("dbo.NextOfKins", "Camper_CamperId");
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            CreateIndex("dbo.Campers", "NextOfKin_NextOfKinID");
            CreateIndex("dbo.Cabins", "Camper_CamperId");
            AddForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers", "CamperId");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
            AddForeignKey("dbo.Cabins", "Camper_CamperId", "dbo.Campers", "CamperId");
            AddForeignKey("dbo.Campers", "NextOfKin_NextOfKinID", "dbo.NextOfKins", "NextOfKinID");
        }
    }
}
