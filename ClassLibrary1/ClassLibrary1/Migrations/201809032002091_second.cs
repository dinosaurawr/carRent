namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cars", name: "Times", newName: "BookedDates");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Cars", name: "BookedDates", newName: "Times");
        }
    }
}
