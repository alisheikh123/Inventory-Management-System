namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateINVOICETABLE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblInvoices", "userId", "dbo.Users");
            DropIndex("dbo.tblInvoices", new[] { "userId" });
            AddColumn("dbo.tblInvoices", "CompanyName", c => c.String(nullable: false));
            AddColumn("dbo.tblInvoices", "customerName", c => c.String());
            AlterColumn("dbo.tblInvoices", "Invoice_type", c => c.Int(nullable: false));
            AlterColumn("dbo.tblInvoices", "payment_Mode", c => c.Int(nullable: false));
            DropColumn("dbo.tblInvoices", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblInvoices", "userId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblInvoices", "payment_Mode", c => c.String());
            AlterColumn("dbo.tblInvoices", "Invoice_type", c => c.String(nullable: false));
            DropColumn("dbo.tblInvoices", "customerName");
            DropColumn("dbo.tblInvoices", "CompanyName");
            CreateIndex("dbo.tblInvoices", "userId");
            AddForeignKey("dbo.tblInvoices", "userId", "dbo.Users", "userId", cascadeDelete: true);
        }
    }
}
