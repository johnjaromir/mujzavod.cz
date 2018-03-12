namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racecategoryusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RaceCategoryEGenders", "RaceCategory_Id", "dbo.RaceCategories");
            DropForeignKey("dbo.RaceCategoryEGenders", "EGender_Id", "dbo.EGenders");
            DropForeignKey("dbo.ApplicationUserRaceCategories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserRaceCategories", "RaceCategory_Id", "dbo.RaceCategories");
            DropIndex("dbo.RaceCategoryEGenders", new[] { "RaceCategory_Id" });
            DropIndex("dbo.RaceCategoryEGenders", new[] { "EGender_Id" });
            DropIndex("dbo.ApplicationUserRaceCategories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserRaceCategories", new[] { "RaceCategory_Id" });
            CreateTable(
                "dbo.RaceSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AgeFrom = c.Int(),
                        AgeTo = c.Int(),
                        RaceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategoryId, cascadeDelete: true)
                .Index(t => t.RaceCategoryId);
            
            CreateTable(
                "dbo.RaceCategoryUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        RaceCategoryId = c.Int(nullable: false),
                        RaceSubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RaceSubCategories", t => t.RaceSubCategoryId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.RaceCategoryId)
                .Index(t => t.RaceSubCategoryId);
            
            CreateTable(
                "dbo.RaceSubCategoryEGenders",
                c => new
                    {
                        RaceSubCategory_Id = c.Int(nullable: false),
                        EGender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RaceSubCategory_Id, t.EGender_Id })
                .ForeignKey("dbo.RaceSubCategories", t => t.RaceSubCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.EGenders", t => t.EGender_Id, cascadeDelete: true)
                .Index(t => t.RaceSubCategory_Id)
                .Index(t => t.EGender_Id);
            
            DropColumn("dbo.RaceCategories", "AgeFrom");
            DropColumn("dbo.RaceCategories", "AgeTo");
            DropTable("dbo.RaceCategoryEGenders");
            DropTable("dbo.ApplicationUserRaceCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserRaceCategories",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        RaceCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.RaceCategory_Id });
            
            CreateTable(
                "dbo.RaceCategoryEGenders",
                c => new
                    {
                        RaceCategory_Id = c.Int(nullable: false),
                        EGender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RaceCategory_Id, t.EGender_Id });
            
            AddColumn("dbo.RaceCategories", "AgeTo", c => c.Int());
            AddColumn("dbo.RaceCategories", "AgeFrom", c => c.Int());
            DropForeignKey("dbo.RaceSubCategories", "RaceCategoryId", "dbo.RaceCategories");
            DropForeignKey("dbo.RaceCategoryUsers", "RaceSubCategoryId", "dbo.RaceSubCategories");
            DropForeignKey("dbo.RaceCategoryUsers", "RaceCategoryId", "dbo.RaceCategories");
            DropForeignKey("dbo.RaceCategoryUsers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceSubCategoryEGenders", "EGender_Id", "dbo.EGenders");
            DropForeignKey("dbo.RaceSubCategoryEGenders", "RaceSubCategory_Id", "dbo.RaceSubCategories");
            DropIndex("dbo.RaceSubCategoryEGenders", new[] { "EGender_Id" });
            DropIndex("dbo.RaceSubCategoryEGenders", new[] { "RaceSubCategory_Id" });
            DropIndex("dbo.RaceCategoryUsers", new[] { "RaceSubCategoryId" });
            DropIndex("dbo.RaceCategoryUsers", new[] { "RaceCategoryId" });
            DropIndex("dbo.RaceCategoryUsers", new[] { "ApplicationUserId" });
            DropIndex("dbo.RaceSubCategories", new[] { "RaceCategoryId" });
            DropTable("dbo.RaceSubCategoryEGenders");
            DropTable("dbo.RaceCategoryUsers");
            DropTable("dbo.RaceSubCategories");
            CreateIndex("dbo.ApplicationUserRaceCategories", "RaceCategory_Id");
            CreateIndex("dbo.ApplicationUserRaceCategories", "ApplicationUser_Id");
            CreateIndex("dbo.RaceCategoryEGenders", "EGender_Id");
            CreateIndex("dbo.RaceCategoryEGenders", "RaceCategory_Id");
            AddForeignKey("dbo.ApplicationUserRaceCategories", "RaceCategory_Id", "dbo.RaceCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserRaceCategories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RaceCategoryEGenders", "EGender_Id", "dbo.EGenders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RaceCategoryEGenders", "RaceCategory_Id", "dbo.RaceCategories", "Id", cascadeDelete: true);
        }
    }
}
