using ElectricalEntityLib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ElectricalDbSqliteLib
{
    public class ElectricalDbContext : ElectricalDbContextBase
    {
        static SqliteConnection _connection = null;
        static ElectricalDbContext _dbContext = null;

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

        public static void Cleanup()
        {
            _dbContext.Dispose();
            _connection.Dispose();
        }

        public ElectricalDbContext(DbContextOptions<ElectricalDbContext> options) : base(options) { }

    }
}