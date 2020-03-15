namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NyDagNyaMöjligheter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropIndex("dbo.Campers", new[] { "CabinID" });
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            RenameColumn(table: "dbo.NextOfKins", name: "CamperID", newName: "Camper_CamperId");
            AddColumn("dbo.Cabins", "CamperID", c => c.Int(nullable: false));
            AddColumn("dbo.Campers", "NextOFKinID", c => c.Int(nullable: false));
            AlterColumn("dbo.Campers", "Cabin_CabinID", c => c.Int());
            AlterColumn("dbo.NextOfKins", "Camper_CamperId", c => c.Int());
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            CreateIndex("dbo.NextOfKins", "Camper_CamperId");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
            AddForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers", "CamperId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.NextOfKins", new[] { "Camper_CamperId" });
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            AlterColumn("dbo.NextOfKins", "Camper_CamperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Campers", "Cabin_CabinID", c => c.Int(nullable: false));
            DropColumn("dbo.Campers", "NextOFKinID");
            DropColumn("dbo.Cabins", "CamperID");
            RenameColumn(table: "dbo.NextOfKins", name: "Camper_CamperId", newName: "CamperID");
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            CreateIndex("dbo.NextOfKins", "CamperID");
            CreateIndex("dbo.Campers", "CabinID");
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
        }
    }
}
