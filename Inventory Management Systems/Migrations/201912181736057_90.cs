namespace Inventory_Management_Systems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _90 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "phone", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sales", "phone", c => c.String());
        }
    }
}
