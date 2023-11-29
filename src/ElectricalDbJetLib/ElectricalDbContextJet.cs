using ElectricalEntityLib;
using Microsoft.EntityFrameworkCore;

namespace ElectricalDbJetLib
{
    /// <summary>
    /// Subclass inherting from a common DbContext base class
    /// </summary>
    public class ElectricalDbContextJet : ElectricalDbContextBase
    {
        /// <summary>
        /// Configure the DbContext to use the JET data provider accessing a Microsoft Access file.
        /// Note, this implementation will delete the existing the data file.
        /// Only use this method during testing.
        /// </summary>
        /// <param name="fileName">Microsoft Access data file</param>
        /// <returns></returns>
        public static ElectricalDbContextBase InitDB(string fileName)
        {
            var contextOptions = new DbContextOptionsBuilder<ElectricalDbContextJet>()
                .UseJet(string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};", fileName))
                .Options;

            var dbContext = new ElectricalDbContextJet(contextOptions);
            
            // WARNING: Will delete the existing data file
            dbContext.Database.EnsureDeleted();

            // Only create the relational objects if the database is empty.
            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        /// <summary>
        /// Using a generic version of DbContextOptions
        /// </summary>
        /// <param name="options">Generic version of DbContextOptions</param>
        public ElectricalDbContextJet(DbContextOptions<ElectricalDbContextJet> options) : base(options)
        {

        }
    }
}