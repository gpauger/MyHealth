namespace MyHealth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log", "ScoreCard_ID", c => c.Int());
            CreateIndex("dbo.Log", "ScoreCard_ID");
            AddForeignKey("dbo.Log", "ScoreCard_ID", "dbo.ScoreCard", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log", "ScoreCard_ID", "dbo.ScoreCard");
            DropIndex("dbo.Log", new[] { "ScoreCard_ID" });
            DropColumn("dbo.Log", "ScoreCard_ID");
        }
    }
}
