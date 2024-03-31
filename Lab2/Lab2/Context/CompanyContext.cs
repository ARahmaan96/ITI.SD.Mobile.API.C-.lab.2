using Lab2.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab2.Context
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions option) : base(option) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany(S => S.Courses).WithMany(C => C.Students).UsingEntity(j => j.ToTable("StudentCourses"));
        }


    }
}
