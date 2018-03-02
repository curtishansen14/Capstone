namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hellouserlaborswithuserquestfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLabors", "UserQuestid", c => c.Int(nullable: false));
            CreateIndex("dbo.UserLabors", "UserQuestid");
            AddForeignKey("dbo.UserLabors", "UserQuestid", "dbo.UserQuests", "UserQuestid", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLabors", "UserQuestid", "dbo.UserQuests");
            DropIndex("dbo.UserLabors", new[] { "UserQuestid" });
            DropColumn("dbo.UserLabors", "UserQuestid");
        }
    }
}
