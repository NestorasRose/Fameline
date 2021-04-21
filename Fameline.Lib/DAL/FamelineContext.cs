using Fameline.Lib.Models;
using Microsoft.EntityFrameworkCore;
namespace Fameline.Lib.DAL
{
    public class FamelineContext : DbContext
    {

        public FamelineContext(DbContextOptions<FamelineContext> options) : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }

        public DbSet<Fleet> Fleets { get; set; }

        public DbSet<Container> Containers { get; set; }


    }
}
