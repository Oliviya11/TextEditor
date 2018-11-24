using DBModels;
using System.Data.Entity;

namespace TextEditor.managers
{
    public class TextEditorDbContext : DbContext
    {
        public TextEditorDbContext() : base("DbConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TextEditorDbContext, TextEditor.Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EditingInfo> EditingInfos { get; set; }


    }

}
