namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblCustomerChane : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCompanies",
                c => new
                    {
                        companyId = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                        webaddress = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.companyId);
            
            CreateTable(
                "dbo.tblCustomers",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        CustomerCode = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.customerId);
            
            AddColumn("dbo.tblInvoices", "companyId", c => c.Int());
            AddColumn("dbo.tblInvoices", "customerId", c => c.Int());
            CreateIndex("dbo.tblInvoices", "companyId");
            CreateIndex("dbo.tblInvoices", "customerId");
            AddForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies", "companyId");
            AddForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers", "customerId");
            DropColumn("dbo.tblInvoices", "CompanyName");
            DropColumn("dbo.tblInvoices", "customerName");
         
        
        }
        
        public override void Down()
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
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyCode = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(),
                        webaddress = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.tblInvoices", "customerName", c => c.String());
            AddColumn("dbo.tblInvoices", "CompanyName", c => c.String(nullable: false));
            DropForeignKey("dbo.tblInvoices", "customerId", "dbo.tblCustomers");
            DropForeignKey("dbo.tblInvoices", "companyId", "dbo.tblCompanies");
            DropIndex("dbo.tblInvoices", new[] { "customerId" });
            DropIndex("dbo.tblInvoices", new[] { "companyId" });
            DropColumn("dbo.tblInvoices", "customerId");
            DropColumn("dbo.tblInvoices", "companyId");
            DropTable("dbo.tblCustomers");
            DropTable("dbo.tblCompanies");
        }
    }
}
