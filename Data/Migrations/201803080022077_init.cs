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
                        RaceCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategory_Id)
                .Index(t => t.RaceCategory_Id);
            
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
                "dbo.RaceRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Distance = c.Double(nullable: false),
                        RaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .Index(t => t.RaceId);
            
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
                "dbo.RaceCategoryApplicationUsers",
                c => new
                    {
                        RaceCategory_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RaceCategory_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.RaceCategories", t => t.RaceCategory_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.RaceCategory_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceCategoryApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceCategoryApplicationUsers", "RaceCategory_Id", "dbo.RaceCategories");
            DropForeignKey("dbo.RaceRoundUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RaceRoundUsers", "RaceRoundId", "dbo.RaceRounds");
            DropForeignKey("dbo.RaceRounds", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceCategories", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Races", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.EGenders", "RaceCategory_Id", "dbo.RaceCategories");
            DropForeignKey("dbo.AspNetUsers", "OrganizerId", "dbo.Organizers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "EGenderId", "dbo.EGenders");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RaceCategoryApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RaceCategoryApplicationUsers", new[] { "RaceCategory_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.RaceRoundUsers", new[] { "RaceRoundId" });
            DropIndex("dbo.RaceRoundUsers", new[] { "UserId" });
            DropIndex("dbo.RaceRounds", new[] { "RaceId" });
            DropIndex("dbo.Races", new[] { "OrganizerId" });
            DropIndex("dbo.RaceCategories", new[] { "RaceId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "OrganizerId" });
            DropIndex("dbo.AspNetUsers", new[] { "EGenderId" });
            DropIndex("dbo.EGenders", new[] { "RaceCategory_Id" });
            DropTable("dbo.RaceCategoryApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.RaceRoundUsers");
            DropTable("dbo.RaceRounds");
            DropTable("dbo.Races");
            DropTable("dbo.RaceCategories");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Organizers");
            DropTable("dbo.EGenders");
        }
    }
}
