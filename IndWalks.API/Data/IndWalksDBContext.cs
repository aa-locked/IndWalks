using IndWalks.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndWalks.API.Data
{
    public class IndWalksDBContext : DbContext
    {
        public IndWalksDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
