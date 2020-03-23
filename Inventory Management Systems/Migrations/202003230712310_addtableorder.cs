namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ProductName", "dbo.tblItems");
            DropIndex("dbo.Sales", new[] { "ProductName" });
            CreateTable(
                "dbo.tblOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemName = c.Int(nullable: false),
                        ItemUnit = c.Int(),
                        Quantity = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        discount = c.Double(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        totalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BalanceDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        status = c.Int(nullable: false),
                        Description = c.String(),
                        current_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblItems", t => t.itemName, cascadeDelete: true)
                .ForeignKey("dbo.tblItemUnits", t => t.ItemUnit)
                .Index(t => t.itemName)
                .Index(t => t.ItemUnit);
            
            AddColumn("dbo.tblItems", "Quantity", c => c.Int(nullable: false));
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.Int(nullable: false),
                        unit = c.Int(nullable: false),
                        current_Date = c.DateTime(nullable: false),
                        customerName = c.String(),
                        Address = c.String(),
                        phone = c.Int(nullable: false),
                        discount = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.tblOrders", "ItemUnit", "dbo.tblItemUnits");
            DropForeignKey("dbo.tblOrders", "itemName", "dbo.tblItems");
            DropIndex("dbo.tblOrders", new[] { "ItemUnit" });
            DropIndex("dbo.tblOrders", new[] { "itemName" });
            DropColumn("dbo.tblItems", "Quantity");
            DropTable("dbo.tblOrders");
            CreateIndex("dbo.Sales", "ProductName");
            AddForeignKey("dbo.Sales", "ProductName", "dbo.tblItems", "itemId", cascadeDelete: true);
        }
    }
}
