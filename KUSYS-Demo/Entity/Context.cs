using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Entity
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrolled> Enrolleds { get; set; }
    }
}
