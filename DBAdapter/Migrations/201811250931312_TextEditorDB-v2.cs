namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TextEditorDBv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditingInfoes", "IsFileChanged", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.EditingInfoes", "IsFileChanged");
        }
    }
}
