namespace MujZavod.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class racepublish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Races", "RaceKey", c => c.String());
            AddColumn("dbo.Races", "PublishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Races", "PublishDate");
            DropColumn("dbo.Races", "RaceKey");
        }
    }
}
