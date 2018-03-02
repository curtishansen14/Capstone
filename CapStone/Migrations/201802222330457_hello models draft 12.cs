namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hellomodelsdraft12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLabors",
                c => new
                    {
                        UserLaborId = c.Int(nullable: false, identity: true),
                        Labor_ID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        isComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserLaborId)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Labors", t => t.Labor_ID, cascadeDelete: true)
                .Index(t => t.Labor_ID)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserQuests",
                c => new
                    {
                        UserQuestid = c.Int(nullable: false, identity: true),
                        Quest_ID = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                        isActive = c.Boolean(nullable: false),
                        isComplete = c.Boolean(nullable: false),
                        rating = c.Int(),
                    })
                .PrimaryKey(t => t.UserQuestid)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Quests", t => t.Quest_ID, cascadeDelete: true)
                .Index(t => t.Quest_ID)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserTargetDates",
                c => new
                    {
                        UserTargetDateid = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        datetime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserTargetDateid)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTargetDates", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserQuests", "Quest_ID", "dbo.Quests");
            DropForeignKey("dbo.UserQuests", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLabors", "Labor_ID", "dbo.Labors");
            DropForeignKey("dbo.UserLabors", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserTargetDates", new[] { "Id" });
            DropIndex("dbo.UserQuests", new[] { "Id" });
            DropIndex("dbo.UserQuests", new[] { "Quest_ID" });
            DropIndex("dbo.UserLabors", new[] { "Id" });
            DropIndex("dbo.UserLabors", new[] { "Labor_ID" });
            DropTable("dbo.UserTargetDates");
            DropTable("dbo.UserQuests");
            DropTable("dbo.UserLabors");
        }
    }
}
