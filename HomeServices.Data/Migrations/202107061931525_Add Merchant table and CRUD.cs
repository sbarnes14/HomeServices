namespace HomeServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMerchanttableandCRUD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Merchant",
                c => new
                    {
                        MerchantId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MerchantName = c.String(nullable: false),
                        TypeService = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MerchantId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Merchant");
        }
    }
}
