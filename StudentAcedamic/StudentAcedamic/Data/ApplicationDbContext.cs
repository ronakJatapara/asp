using Microsoft.EntityFrameworkCore;
using StudentAcedamic.Models;

namespace StudentAcedamic.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Mark)
                .WithOne(s => s.Student)
                .HasForeignKey<Mark>(m => m.StudentId);
        }
    }
}
