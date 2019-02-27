namespace MyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScoreCard",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScoretDate = c.DateTime(nullable: false),
                        DayScore = c.Int(nullable: false),
                        WeekScore = c.Int(nullable: false),
                        TotalScore = c.Int(nullable: false),
                        user_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.user_ID)
                .Index(t => t.user_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScoreCard", "user_ID", "dbo.User");
            DropIndex("dbo.ScoreCard", new[] { "user_ID" });
            DropTable("dbo.ScoreCard");
        }
    }
}
