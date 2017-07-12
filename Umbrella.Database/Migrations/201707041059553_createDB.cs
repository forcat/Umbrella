namespace Umbrella.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.sys_device",
                c => new
                    {
                        DeviceId = c.String(nullable: false, maxLength: 128, unicode: false, storeType: "nvarchar"),
                        ReaderIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sys_device");
        }
    }
}
