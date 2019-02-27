namespace MyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entry",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntrytDate = c.DateTime(nullable: false),
                        String = c.String(),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LogtDate = c.DateTime(nullable: false),
                        Bedtime = c.Double(nullable: false),
                        Alcohol = c.Double(nullable: false),
                        Exercise = c.Double(nullable: false),
                        Veggies = c.Double(nullable: false),
                        Meditation = c.Double(nullable: false),
                        Read = c.Double(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
            CreateTable(
                "dbo.Measurements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeasurementDate = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Belly = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        Thigh = c.Double(nullable: false),
                        Bicep = c.Double(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Measurements", "user_ID", "dbo.User");
            DropForeignKey("dbo.Log", "user_ID", "dbo.User");
            DropForeignKey("dbo.Entry", "user_ID", "dbo.User");
            DropIndex("dbo.Measurements", new[] { "user_ID" });
            DropIndex("dbo.Log", new[] { "user_ID" });
            DropIndex("dbo.Entry", new[] { "user_ID" });
            DropTable("dbo.Measurements");
            DropTable("dbo.Log");
            DropTable("dbo.User");
            DropTable("dbo.Entry");
        }
    }
}
