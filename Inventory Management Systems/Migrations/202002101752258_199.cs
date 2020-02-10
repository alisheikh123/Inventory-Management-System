namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _199 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerCode = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
