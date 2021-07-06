namespace HomeServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appliance", "Property_PropertyId", "dbo.Property");
            DropIndex("dbo.Appliance", new[] { "Property_PropertyId" });
            RenameColumn(table: "dbo.Appliance", name: "Property_PropertyId", newName: "PropertyId");
            AlterColumn("dbo.Appliance", "PropertyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Appliance", "PropertyId");
            AddForeignKey("dbo.Appliance", "PropertyId", "dbo.Property", "PropertyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appliance", "PropertyId", "dbo.Property");
            DropIndex("dbo.Appliance", new[] { "PropertyId" });
            AlterColumn("dbo.Appliance", "PropertyId", c => c.Int());
            RenameColumn(table: "dbo.Appliance", name: "PropertyId", newName: "Property_PropertyId");
            CreateIndex("dbo.Appliance", "Property_PropertyId");
            AddForeignKey("dbo.Appliance", "Property_PropertyId", "dbo.Property", "PropertyId");
        }
    }
}
