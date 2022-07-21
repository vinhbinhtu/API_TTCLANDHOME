using KOG.Intergration.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace KOG.Intergration.Models
{
    public class KOGIntergrationDBContext : DbContext
    {
        public KOGIntergrationDBContext(DbContextOptions<KOGIntergrationDBContext> options) : base(options)
        {
        }

        public virtual DbSet<DAO_R81DMDT> R81DMDT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}