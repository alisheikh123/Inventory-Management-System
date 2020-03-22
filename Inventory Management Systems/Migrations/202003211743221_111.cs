namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies");
            DropForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers");
            DropIndex("dbo.tblInvoices", new[] { "companyId" });
            DropIndex("dbo.tblInvoices", new[] { "customerId" });
            AlterColumn("dbo.tblInvoices", "companyId", c => c.Int(nullable: false));
            AlterColumn("dbo.tblInvoices", "customerId", c => c.Int(nullable: false));
            CreateIndex("dbo.tblInvoices", "companyId");
            CreateIndex("dbo.tblInvoices", "customerId");
            AddForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies", "companyId", cascadeDelete: true);
            AddForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers", "customerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers");
            DropForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies");
            DropIndex("dbo.tblInvoices", new[] { "customerId" });
            DropIndex("dbo.tblInvoices", new[] { "companyId" });
            AlterColumn("dbo.tblInvoices", "customerId", c => c.Int());
            AlterColumn("dbo.tblInvoices", "companyId", c => c.Int());
            CreateIndex("dbo.tblInvoices", "customerId");
            CreateIndex("dbo.tblInvoices", "companyId");
            AddForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers", "customerId");
            AddForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies", "companyId");
        }
    }
}
