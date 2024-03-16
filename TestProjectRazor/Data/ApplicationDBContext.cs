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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("USER");
        }


    }
}
