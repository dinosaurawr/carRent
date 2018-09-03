namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "BookedDates", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "BookedDates");
        }
    }
}
