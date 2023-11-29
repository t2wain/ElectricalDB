using ElectricalDbSqliteLib;
using ElectricalEntityLib;

namespace DbTest
{
    public class DatabaseFixture
    {
        ElectricalDbContextBase _dbCtx;
        TestRepo _repo;

        public DatabaseFixture()
        {
            // using sql in-memory data provider
            _dbCtx = ElectricalDbContext.MemoryDbContext;
            _repo = new TestRepo(_dbCtx);
        }

        public TestRepo Repo => _repo;

        public ElectricalDbContextBase DbContext => _dbCtx;

    }
}
