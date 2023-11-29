using ElectricalEntityLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ElectricalDbSqliteLib
{
    /// <summary>
    /// Subclass inherting from a common DbContext base class
    /// </summary>
    public class ElectricalDbContext : ElectricalDbContextBase
    {
        static SqliteConnection _connection = null;
        static ElectricalDbContext _dbContext = null;

        /// <summary>
        /// Configure DbContext to use Sqlite in-memory data provider. 
        /// This data provider is used in the unit test project. 
        /// </summary>
        public static ElectricalDbContext MemoryDbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
                    // at the end of the test (see Dispose below).
                    _connection = new SqliteConnection("Filename=:memory:");
                    _connection.Open();

                    // These options will be used by the context instances in this test suite, including the connection opened above.
                    var _contextOptions = new DbContextOptionsBuilder<ElectricalDbContext>()
                        .UseSqlite(_connection)
                        .Options;

                    _dbContext = new ElectricalDbContext(_contextOptions);
                    _dbContext.Database.EnsureCreated();
                }
                return _dbContext;
            }
        }

        /// <summary>
        /// Configure the DbContext using the Sqlite data provider.
        /// Note, this implementation will delete the existing the data file.
        /// Only use this method during testing.
        /// </summary>
        /// <param name="fileName">Sqlite data file</param>
        /// <returns></returns>
        public static ElectricalDbContextBase InitDB(string fileName)
        {
            var contextOptions = new DbContextOptionsBuilder<ElectricalDbContext>()
                .UseSqlite(String.Format("Data source = {0}", fileName))
                .Options;

            var dbContext = new ElectricalDbContext(contextOptions);

            // WARNING: Will delete the existing data file
            dbContext.Database.EnsureDeleted();

            // Only create the relational objects if the database is empty.
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        public static void Cleanup()
        {
            _dbContext.Dispose();
            _connection.Dispose();
        }

        /// <summary>
        /// Using a generic version of DbContextOptions
        /// </summary>
        /// <param name="options">Generic version of DbContextOptions</param>
        public ElectricalDbContext(DbContextOptions<ElectricalDbContext> options) : base(options) { }

    }
}