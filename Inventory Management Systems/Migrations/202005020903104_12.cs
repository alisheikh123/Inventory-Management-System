namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblOrders", "ItemUnit", c => c.Int());
            AlterColumn("dbo.tblOrders", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblOrders", "price", c => c.String());
            AlterColumn("dbo.tblOrders", "ItemUnit", c => c.String());
        }
    }
}
