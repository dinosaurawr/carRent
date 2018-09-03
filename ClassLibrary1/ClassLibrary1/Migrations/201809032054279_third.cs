namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "BookedDates");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "BookedDates", c => c.String());
        }
    }
}
