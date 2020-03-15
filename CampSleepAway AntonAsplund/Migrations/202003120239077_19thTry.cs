namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19thTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers");
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            DropIndex("dbo.NextOfKins", new[] { "Camper_CamperId" });
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            RenameColumn(table: "dbo.NextOfKins", name: "Camper_CamperId", newName: "CamperID");
            RenameIndex(table: "dbo.Cabins", name: "IX_CabinUniqueCounselor", newName: "IX_CounselorUniqueSSN");
            AlterColumn("dbo.Campers", "CabinID", c => c.Int(nullable: false));
            AlterColumn("dbo.NextOfKins", "CamperID", c => c.Int(nullable: false));
            CreateIndex("dbo.Campers", "CabinID");
            CreateIndex("dbo.NextOfKins", "CamperID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
            AddForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers", "CamperId", cascadeDelete: true);
            DropColumn("dbo.Cabins", "CamperID");
            DropColumn("dbo.Campers", "NextOfKinID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campers", "NextOfKinID", c => c.Int(nullable: false));
            AddColumn("dbo.Cabins", "CamperID", c => c.Int(nullable: false));
            DropForeignKey("dbo.NextOfKins", "CamperID", "dbo.Campers");
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropIndex("dbo.NextOfKins", new[] { "CamperID" });
            DropIndex("dbo.Campers", new[] { "CabinID" });
            AlterColumn("dbo.NextOfKins", "CamperID", c => c.Int());
            AlterColumn("dbo.Campers", "CabinID", c => c.Int());
            RenameIndex(table: "dbo.Cabins", name: "IX_CounselorUniqueSSN", newName: "IX_CabinUniqueCounselor");
            RenameColumn(table: "dbo.NextOfKins", name: "CamperID", newName: "Camper_CamperId");
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            CreateIndex("dbo.NextOfKins", "Camper_CamperId");
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            AddForeignKey("dbo.NextOfKins", "Camper_CamperId", "dbo.Campers", "CamperId");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
        }
    }
}
