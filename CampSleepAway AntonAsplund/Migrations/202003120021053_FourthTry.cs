namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "CabinID" });
            RenameColumn(table: "dbo.Campers", name: "CabinID", newName: "Cabin_CabinID");
            AlterColumn("dbo.Campers", "Cabin_CabinID", c => c.Int());
            CreateIndex("dbo.Campers", "Cabin_CabinID");
            AddForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins", "CabinID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campers", "Cabin_CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "Cabin_CabinID" });
            AlterColumn("dbo.Campers", "Cabin_CabinID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Campers", name: "Cabin_CabinID", newName: "CabinID");
            CreateIndex("dbo.Campers", "CabinID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
        }
    }
}
