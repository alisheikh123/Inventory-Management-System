namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblItems", "Percentage", c => c.Int(nullable: false));
            AddColumn("dbo.tblItems", "Alert", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblItems", "Alert");
            DropColumn("dbo.tblItems", "Percentage");
        }
    }
}
