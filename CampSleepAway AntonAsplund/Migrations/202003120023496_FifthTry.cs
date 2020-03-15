namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            RenameColumn(table: "dbo.NextOfKins", name: "CamperID", newName: "Camper_CamperId");
            AlterColumn("dbo.NextOfKins", "Camper_CamperId", c => c.Int());
            CreateIndex("dbo.NextOfKins", "Camper_CamperId");
            AddForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers", "CamperId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers");
            DropIndex("dbo.NextOfKins", new[] { "Camper_CamperId" });
            AlterColumn("dbo.NextOfKins", "Camper_CamperId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.NextOfKins", name: "Camper_CamperId", newName: "CamperID");
            CreateIndex("dbo.NextOfKins", "CamperID");
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
        }
    }
}
