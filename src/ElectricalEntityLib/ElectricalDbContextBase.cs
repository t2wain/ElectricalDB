using ElectricalEntityLib.Config;
using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElectricalEntityLib
{
    /// <summary>
    /// This is an abstract DbContext class. The subclasses will specify the specific data providers.
    /// </summary>
    public abstract class ElectricalDbContextBase : DbContext
    {
        /// <summary>
        /// A non-generic DbContextOptions implementation is required for any
        /// DbContext class that is to be inherited.
        /// </summary>
        /// <param name="options">Non-generic DbContextOptions</param>
        protected ElectricalDbContextBase(DbContextOptions options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cable> Cables { get; set; }
        public DbSet<CableFill> CableFills { get; set; }
        public DbSet<CableSpec> CableSpecs { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<LookUp> LookUps { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Raceway> Raceways { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RoutePath> RoutePaths { get; set; }
        public DbSet<RouteRacewaySpec> RouteRacewaySpecs { get; set; }
        public DbSet<RouteSpec> RouteSpecs { get; set; }
        public DbSet<SegSystem> SegSystems { get; set; }
        public DbSet<TraySpec> TraySpecs { get; set; }

        /// <summary>
        /// Entity model configuration that prefers the following orderly approaches:
        ///    1. Common convention
        ///    2. Mapping attributes
        ///    3. Fluent APIs
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NodeEntityTypeConfiguration).Assembly);
        }
    }
}
