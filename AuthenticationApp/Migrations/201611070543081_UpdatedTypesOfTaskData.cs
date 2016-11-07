namespace AuthenticationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTypesOfTaskData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskDatas", "CustomerId", c => c.String());
            AlterColumn("dbo.TaskDatas", "VenderId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskDatas", "VenderId", c => c.Guid(nullable: false));
            AlterColumn("dbo.TaskDatas", "CustomerId", c => c.Guid(nullable: false));
        }
    }
}
