using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;


namespace TheBlogToRestart.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("BlogConnection")
        {
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<BlogContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
