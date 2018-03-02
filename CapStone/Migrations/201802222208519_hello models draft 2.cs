namespace CapStone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hellomodelsdraft2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ETAs",
                c => new
                    {
                        ETA_ID = c.Int(nullable: false, identity: true),
                        TIME = c.String(),
                    })
                .PrimaryKey(t => t.ETA_ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        theme = c.String(),
                    })
                .PrimaryKey(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Topics");
            DropTable("dbo.ETAs");
        }
    }
}
