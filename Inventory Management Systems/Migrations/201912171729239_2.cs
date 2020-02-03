namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.Int(nullable: false),
                        current_Date = c.DateTime(nullable: false),
                        customerName = c.String(),
                        Address = c.String(),
                        discount = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblItems", t => t.ProductName, cascadeDelete: true)
                .Index(t => t.ProductName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ProductName", "dbo.tblItems");
            DropIndex("dbo.Sales", new[] { "ProductName" });
            DropTable("dbo.Sales");
        }
    }
}
