using ElectricalEntityLib.Config;
using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElectricalEntityLib
{
    public abstract class ElectricalDbContextBase : DbContext
    {
        protected ElectricalDbContextBase(DbContextOptions options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<CableFill> CableFills { get; set; }
        public DbSet<CableSpec> CableSpecs { get; set; }
        public DbSet<LookUp> LookUps { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Raceway> Raceways { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePath> RoutePaths { get; set; }
        public DbSet<RouteRacewaySpec> RouteRacewaySpecs { get; set; }
        public DbSet<RouteSpec> RouteSpecs { get; set; }
        public DbSet<SegSystem> SegSystems { get; set; }
        public DbSet<TraySpec> TraySpecs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NodeEntityTypeConfiguration).Assembly);
        }
    }
}
