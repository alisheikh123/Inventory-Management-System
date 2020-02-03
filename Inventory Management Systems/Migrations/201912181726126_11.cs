namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "unit", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "phone");
            DropColumn("dbo.Sales", "unit");
        }
    }
}
