namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hellotargetdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserQuests", "Target", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserQuests", "Target");
        }
    }
}
