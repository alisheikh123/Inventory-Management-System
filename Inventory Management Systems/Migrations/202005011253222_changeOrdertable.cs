namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrdertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblOrders", "itemName", "dbo.tblItems");
            DropForeignKey("dbo.tblOrders", "ItemUnit", "dbo.tblItemUnits");
            DropIndex("dbo.tblOrders", new[] { "itemName" });
            DropIndex("dbo.tblOrders", new[] { "ItemUnit" });
            AlterColumn("dbo.tblOrders", "itemName", c => c.String(nullable: false));
            AlterColumn("dbo.tblOrders", "ItemUnit", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblOrders", "ItemUnit", c => c.Int());
            AlterColumn("dbo.tblOrders", "itemName", c => c.Int(nullable: false));
            CreateIndex("dbo.tblOrders", "ItemUnit");
            CreateIndex("dbo.tblOrders", "itemName");
            AddForeignKey("dbo.tblOrders", "ItemUnit", "dbo.tblItemUnits", "unitId");
            AddForeignKey("dbo.tblOrders", "itemName", "dbo.tblItems", "itemId", cascadeDelete: true);
        }
    }
}
