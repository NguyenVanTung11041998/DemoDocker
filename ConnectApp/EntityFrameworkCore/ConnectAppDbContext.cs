using ConnectApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConnectApp.EntityFrameworkCore
{
    public class ConnectAppDbContext : DbContext
    {
        public virtual DbSet<SampleA> SampleAs { get; set; }
        public virtual DbSet<SampleB> SampleBs { get; set; }
        public virtual DbSet<SampleC> SampleCs { get; set; }
        public virtual DbSet<SampleD> SampleDs { get; set; }

        public ConnectAppDbContext(DbContextOptions<ConnectAppDbContext> options) : base(options)
        {
        }
    }
}
