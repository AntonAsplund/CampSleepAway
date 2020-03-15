namespace CampSleepAway_AntonAsplund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuBörjarDeSeLjusareUt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "CabinID" });
            AlterColumn("dbo.Cabins", "CabinNickName", c => c.String(nullable: false));
            AlterColumn("dbo.Campers", "CabinID", c => c.Int());
            CreateIndex("dbo.Campers", "CabinID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campers", "CabinID", "dbo.Cabins");
            DropIndex("dbo.Campers", new[] { "CabinID" });
            AlterColumn("dbo.Campers", "CabinID", c => c.Int(nullable: false));
            AlterColumn("dbo.Cabins", "CabinNickName", c => c.String());
            CreateIndex("dbo.Campers", "CabinID");
            AddForeignKey("dbo.Campers", "CabinID", "dbo.Cabins", "CabinID", cascadeDelete: true);
        }
    }
}
