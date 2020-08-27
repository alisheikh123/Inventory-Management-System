namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrdertab : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblOrders", "itemName", c => c.Int(nullable: false));
            AlterColumn("dbo.tblOrders", "price", c => c.String());
            CreateIndex("dbo.tblOrders", "itemName");
            AddForeignKey("dbo.tblOrders", "itemName", "dbo.tblItems", "itemId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblOrders", "itemName", "dbo.tblItems");
            DropIndex("dbo.tblOrders", new[] { "itemName" });
            AlterColumn("dbo.tblOrders", "price", c => c.Double(nullable: false));
            AlterColumn("dbo.tblOrders", "itemName", c => c.String(nullable: false));
        }
    }
}
