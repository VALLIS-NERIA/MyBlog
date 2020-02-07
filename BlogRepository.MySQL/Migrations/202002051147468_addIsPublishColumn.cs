namespace BlogRepository.MySQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsPublishColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsPublish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsPublish");
        }
    }
}
