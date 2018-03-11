namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EGenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RaceCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AgeFrom = c.Int(),
                        AgeTo = c.Int(),
                        Start = c.DateTime(nullable: false),
                        RaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizerId = c.Int(nullable: false),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        SignToDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Organizers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EGenderId = c.Int(nullable: false),
                        OrganizerId = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EGenders", t => t.EGenderId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizerId)
                .Index(t => t.EGenderId)
                .Index(t => t.OrganizerId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RaceRoundUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RaceRoundId = c.Int(nullable: false),
                        Time = c.Time(nullable: false, precision: 6),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceRounds", t => t.RaceRoundId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RaceRoundId);
            
            CreateTable(
                "dbo.RaceRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distance = c.Double(nullable: false),
                        RaceCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategoryId, cascadeDelete: true)
                .Index(t => t.RaceCategoryId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RaceCategoryEGenders",
                c => new
                    {
                        RaceCategory_Id = c.Int(nullable: false),
                        EGender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RaceCategory_Id, t.EGender_Id })
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.EGenders", t => t.EGender_Id, cascadeDelete: true)
                .Index(t => t.RaceCategory_Id)
                .Index(t => t.EGender_Id);
            
            CreateTable(
                "dbo.ApplicationUserRaceCategories",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        RaceCategory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.RaceCategory_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategory_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.RaceCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RaceCategories", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceRoundUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceRoundUsers", "RaceRoundId", "dbo.RaceRounds");
            DropForeignKey("dbo.RaceRounds", "RaceCategoryId", "dbo.RaceCategories");
            DropForeignKey("dbo.ApplicationUserRaceCategories", "RaceCategory_Id", "dbo.RaceCategories");
            DropForeignKey("dbo.ApplicationUserRaceCategories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EGenderId", "dbo.EGenders");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceCategoryEGenders", "EGender_Id", "dbo.EGenders");
            DropForeignKey("dbo.RaceCategoryEGenders", "RaceCategory_Id", "dbo.RaceCategories");
            DropIndex("dbo.ApplicationUserRaceCategories", new[] { "RaceCategory_Id" });
            DropIndex("dbo.ApplicationUserRaceCategories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RaceCategoryEGenders", new[] { "EGender_Id" });
            DropIndex("dbo.RaceCategoryEGenders", new[] { "RaceCategory_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RaceRounds", new[] { "RaceCategoryId" });
            DropIndex("dbo.RaceRoundUsers", new[] { "RaceRoundId" });
            DropIndex("dbo.RaceRoundUsers", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "OrganizerId" });
            DropIndex("dbo.AspNetUsers", new[] { "EGenderId" });
            DropIndex("dbo.Races", new[] { "OrganizerId" });
            DropIndex("dbo.RaceCategories", new[] { "RaceId" });
            DropTable("dbo.ApplicationUserRaceCategories");
            DropTable("dbo.RaceCategoryEGenders");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RaceRounds");
            DropTable("dbo.RaceRoundUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Organizers");
            DropTable("dbo.Races");
            DropTable("dbo.RaceCategories");
            DropTable("dbo.EGenders");
        }
    }
}
