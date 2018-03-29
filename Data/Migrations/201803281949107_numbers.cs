namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numbers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RaceCategories", "RegistrationPrice", c => c.Double(nullable: false));
            AddColumn("dbo.RaceCategoryUsers", "RunnerNumber", c => c.Int());
            AddColumn("dbo.RaceCategoryUsers", "IsPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RaceCategoryUsers", "IsPaid");
            DropColumn("dbo.RaceCategoryUsers", "RunnerNumber");
            DropColumn("dbo.RaceCategories", "RegistrationPrice");
        }
    }
}
