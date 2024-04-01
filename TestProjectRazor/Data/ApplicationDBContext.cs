using Microsoft.EntityFrameworkCore;
using TestProjectRazor.Models;

namespace TestProjectRazor.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }
        
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>().ToTable("POSTS");
            modelBuilder.Entity<User>().ToTable("USERS");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(u => u.Author);

                
        }


    }
}
