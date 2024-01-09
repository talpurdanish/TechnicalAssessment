namespace TechnicalAssessment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDtls",
                c => new
                    {
                        OrderDtlID = c.Int(nullable: false, identity: true),
                        OrderNum = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Item = c.String(nullable: false, maxLength: 300),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDtlID)
                .ForeignKey("dbo.OrderHeads", t => t.OrderNum, cascadeDelete: true)
                .Index(t => t.OrderNum);
            
            CreateTable(
                "dbo.OrderHeads",
                c => new
                    {
                        OrderNum = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 250),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderNum);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDtls", "OrderNum", "dbo.OrderHeads");
            DropIndex("dbo.OrderDtls", new[] { "OrderNum" });
            DropTable("dbo.OrderHeads");
            DropTable("dbo.OrderDtls");
        }
    }
}
