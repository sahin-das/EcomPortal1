namespace EcomPortal1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJson1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderProducts", "ProductId");
            AddForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
        }
    }
}
