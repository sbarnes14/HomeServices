namespace HomeServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfullCRUDforWorkOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrder",
                c => new
                    {
                        WorkOrderId = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        TypeService = c.Int(nullable: false),
                        ServiceStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkOrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkOrder");
        }
    }
}
