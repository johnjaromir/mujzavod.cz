namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderincategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RaceCategoryUsers", "OrderInCategory", c => c.Int());
            AddColumn("dbo.RaceCategoryUsers", "OrderInSubCategory", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RaceCategoryUsers", "OrderInSubCategory");
            DropColumn("dbo.RaceCategoryUsers", "OrderInCategory");
        }
    }
}
