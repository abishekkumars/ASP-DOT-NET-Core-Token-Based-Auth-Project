using Microsoft.EntityFrameworkCore;

namespace ABC_Website.Models
{
    public class MovieDbContext : DbContext
    {
        //public MovieDbContext()
        //{

        //}

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> obj { get; set; }
        public DbSet<MovieAk> movies { get; set; }

    }
}
