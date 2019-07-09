using CS321_W5D2_BlogAPI.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        // TODO: create Blogs, Posts, and Comments DbSets
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
                    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // TODO: use Sqlite db
        //    //optionsBuilder.UseSqlite("Data Source=../CS321_W5D2_BlogAPI.Infrastructure/blog.db");
        //    //optionsBuilder.UseSqlServer(Microsoft.Extensions.Configuration.GetConnectionString("AzureDb")));
        //}
    }
}
