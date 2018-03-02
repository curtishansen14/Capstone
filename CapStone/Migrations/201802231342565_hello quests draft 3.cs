namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class helloquestsdraft3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quests", "isFlagged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quests", "isFlagged");
        }
    }
}
