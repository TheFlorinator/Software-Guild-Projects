namespace TheBlogToRestart.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredattributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Posts", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Description", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Description", c => c.String());
            AlterColumn("dbo.Posts", "Author", c => c.String());
            AlterColumn("dbo.Posts", "Address", c => c.String());
            AlterColumn("dbo.Posts", "Image", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
    }
}
