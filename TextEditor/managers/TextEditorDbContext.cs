using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Models;

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
