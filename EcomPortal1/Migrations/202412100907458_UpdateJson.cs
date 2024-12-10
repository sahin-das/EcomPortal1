namespace EcomPortal1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJson : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            CreateIndex("dbo.OrderProducts", "ProductId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products", "Id");
        }
    }
}
