using DockerDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.EntityFrameworkCore
{
    public class DemoDockerDbContext : DbContext
    {
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Student> Students { get; set; }

        public DemoDockerDbContext(DbContextOptions<DemoDockerDbContext> options) : base(options)
        {
        }
    }
}
