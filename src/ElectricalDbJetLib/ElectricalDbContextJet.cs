using ElectricalEntityLib;
using Microsoft.EntityFrameworkCore;

namespace ElectricalDbJetLib
{
    public class ElectricalDbContextJet : ElectricalDbContextBase
    {
        public static ElectricalDbContextBase InitDB(string fileName)
        {
            // These options will be used by the context instances in this test suite, including the connection opened above.
            var contextOptions = new DbContextOptionsBuilder<ElectricalDbContextJet>()
                .UseJet(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};", fileName))
                .Options;

            var dbContext = new ElectricalDbContextJet(contextOptions);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }


        public ElectricalDbContextJet(DbContextOptions<ElectricalDbContextJet> options) : base(options)
        {

        }
    }
}