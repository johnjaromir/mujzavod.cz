namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceroundusers1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RaceRoundUsers", "RaceCategoryUser_Id", "dbo.RaceCategoryUsers");
            DropIndex("dbo.RaceRoundUsers", new[] { "RaceCategoryUser_Id" });
            DropColumn("dbo.RaceRoundUsers", "RaceCategoryUserId");
            RenameColumn(table: "dbo.RaceRoundUsers", name: "RaceCategoryUser_Id", newName: "RaceCategoryUserId");
            AlterColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.Int(nullable: false));
            AlterColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.RaceRoundUsers", "RaceCategoryUserId");
            AddForeignKey("dbo.RaceRoundUsers", "RaceCategoryUserId", "dbo.RaceCategoryUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceRoundUsers", "RaceCategoryUserId", "dbo.RaceCategoryUsers");
            DropIndex("dbo.RaceRoundUsers", new[] { "RaceCategoryUserId" });
            AlterColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.Int());
            AlterColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.String());
            RenameColumn(table: "dbo.RaceRoundUsers", name: "RaceCategoryUserId", newName: "RaceCategoryUser_Id");
            AddColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.String());
            CreateIndex("dbo.RaceRoundUsers", "RaceCategoryUser_Id");
            AddForeignKey("dbo.RaceRoundUsers", "RaceCategoryUser_Id", "dbo.RaceCategoryUsers", "Id");
        }
    }
}
