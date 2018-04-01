namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class raceenddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Races", "EndDate");
        }
    }
}
