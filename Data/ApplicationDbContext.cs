using DecBatch2025MVCCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DecBatch2025MVCCoreProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Emp> employees { get; set; }
        public DbSet<Manager> mang { get; set; }
        public DbSet<Student> stud { get; set; }
        public DbSet<Account> acc { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Emp>(e =>
            {
                e.HasOne(x => x.managers)
                .WithMany(x => x.emps)
                .HasForeignKey(x => x.mid)
                .OnDelete(DeleteBehavior.Restrict);
            });

            
        }
    }
}
