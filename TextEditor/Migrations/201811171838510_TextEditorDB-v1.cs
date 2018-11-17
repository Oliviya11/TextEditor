namespace TextEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextEditorDBv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditingInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FilePath = c.String(),
                        EditingDate = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EditingInfoes", "UserId", "dbo.Users");
            DropIndex("dbo.EditingInfoes", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.EditingInfoes");
        }
    }
}
