namespace AuthenticationApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.TaskDatas",
                c => new
                    {
                        TaskId = c.Guid(nullable: false),
                        UserId = c.String(),
                        UserType = c.Int(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        VenderId = c.Guid(nullable: false),
                        StateId = c.Int(nullable: false),
                        StateName = c.String(),
                        PartNumberRevision = c.Int(nullable: false),
                        MaterialCategory = c.Int(nullable: false),
                        Material = c.Int(nullable: false),
                        MaterialMainType = c.Int(nullable: false),
                        Process = c.Int(nullable: false),
                        SurfaceFinish = c.Int(nullable: false),
                        SwitchesAttributes = c.Int(nullable: false),
                        OverlaysAttributes = c.Int(nullable: false),
                        QuantityBreak = c.Int(nullable: false),
                        LeadTime = c.Int(nullable: false),
                        FileType = c.Int(nullable: false),
                        CreateTC = c.DateTime(nullable: false),
                        UpdateTC = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                    })
                .PrimaryKey(t => t.TaskId);
            

            
        }
        
        public override void Down()
        {
           
        }
    }
}
