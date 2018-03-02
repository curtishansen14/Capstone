namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hellomodelsdraft3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labors",
                c => new
                    {
                        Labor_ID = c.Int(nullable: false, identity: true),
                        Quest_ID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 509),
                        ETA_ID = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Labor_ID)
                .ForeignKey("dbo.ETAs", t => t.ETA_ID, cascadeDelete: false)
                .ForeignKey("dbo.Quests", t => t.Quest_ID, cascadeDelete: true)
                .Index(t => t.Quest_ID)
                .Index(t => t.ETA_ID);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Quest_ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ETA_ID = c.Int(nullable: false),
                        TopicID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Quest_ID)
                .ForeignKey("dbo.ETAs", t => t.ETA_ID, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: false)
                .Index(t => t.ETA_ID)
                .Index(t => t.TopicID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labors", "Quest_ID", "dbo.Quests");
            DropForeignKey("dbo.Quests", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.Quests", "ETA_ID", "dbo.ETAs");
            DropForeignKey("dbo.Labors", "ETA_ID", "dbo.ETAs");
            DropIndex("dbo.Quests", new[] { "TopicID" });
            DropIndex("dbo.Quests", new[] { "ETA_ID" });
            DropIndex("dbo.Labors", new[] { "ETA_ID" });
            DropIndex("dbo.Labors", new[] { "Quest_ID" });
            DropTable("dbo.Quests");
            DropTable("dbo.Labors");
        }
    }
}
