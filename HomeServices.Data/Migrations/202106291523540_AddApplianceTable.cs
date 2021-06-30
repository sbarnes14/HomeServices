namespace HomeServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplianceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appliance",
                c => new
                    {
                        ApplianceId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ApplianceType = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        ApplianceModel = c.String(nullable: false),
                        Property_PropertyId = c.Int(),
                    })
                .PrimaryKey(t => t.ApplianceId)
                .ForeignKey("dbo.Property", t => t.Property_PropertyId)
                .Index(t => t.Property_PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appliance", "Property_PropertyId", "dbo.Property");
            DropIndex("dbo.Appliance", new[] { "Property_PropertyId" });
            DropTable("dbo.Appliance");
        }
    }
}
