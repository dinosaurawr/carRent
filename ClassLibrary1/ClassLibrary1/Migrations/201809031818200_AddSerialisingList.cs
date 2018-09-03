namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSerialisingList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Times", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Times");
        }
    }
}
