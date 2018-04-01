namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceroundusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RaceRoundUsers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RaceRoundUsers", new[] { "UserId" });
            AddColumn("dbo.RaceRoundUsers", "RaceCategoryUserId", c => c.String());
            AddColumn("dbo.RaceRoundUsers", "RaceCategoryUser_Id", c => c.Int());
            CreateIndex("dbo.RaceRoundUsers", "RaceCategoryUser_Id");
            AddForeignKey("dbo.RaceRoundUsers", "RaceCategoryUser_Id", "dbo.RaceCategoryUsers", "Id");
            DropColumn("dbo.RaceRoundUsers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RaceRoundUsers", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.RaceRoundUsers", "RaceCategoryUser_Id", "dbo.RaceCategoryUsers");
            DropIndex("dbo.RaceRoundUsers", new[] { "RaceCategoryUser_Id" });
            DropColumn("dbo.RaceRoundUsers", "RaceCategoryUser_Id");
            DropColumn("dbo.RaceRoundUsers", "RaceCategoryUserId");
            CreateIndex("dbo.RaceRoundUsers", "UserId");
            AddForeignKey("dbo.RaceRoundUsers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
