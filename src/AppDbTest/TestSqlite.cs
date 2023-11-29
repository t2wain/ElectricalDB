using LT = ElectricalDbSqliteLib;
using JT = ElectricalDbJetLib;
using ElectricalEntityLib;

namespace AppDbTest
{
    public class TestSqlite
    {
        public static void Run()
        {
            //TestMemoryDB();
            //InitSqliteDB();
            InitJetDB();
        }

        public static void TestMemoryDB()
        {
            // using Sqlite in-memory data provider
            using var db = LT.ElectricalDbContext.MemoryDbContext;
            var repo = new TestRepo(db);

            repo.AddConductorSizes();
            repo.AddCableSpecs();
            repo.AddSegSystems();
            repo.AddNodes();
            repo.AddCables();
            repo.AddTraySpecs();
            repo.AddRaceways();

            var cables = repo.GetCables();

            foreach (var cable in cables)
                Console.WriteLine(cable.Name);

            var raceways = repo.GetRaceways();

            foreach (var raceway in raceways)
                Console.WriteLine(raceway.Name);

        }

        public static void InitSqliteDB()
        {
            // using Sqlite data provider
            var db = LT.ElectricalDbContext.InitDB("C:\\dev\\electricaldb.db");
            AddData(db);
        }

        public static void InitJetDB()
        {
            // using JET data provider for Microsoft Access data file
            var db = JT.ElectricalDbContextJet.InitDB("C:\\dev\\electricaldb.accdb");
            AddData(db);
        }

        // testing the inserts and queries using DbContext
        protected static void AddData(ElectricalDbContextBase db)
        {
            var repo = new TestRepo(db);
            repo.AddConductorSizes();
            repo.AddSegSystems();
            repo.AddTraySpecs();
            repo.AddNodes();
            repo.AddLoads();
            repo.AddCableSpecs();
            repo.AddRaceways();
            repo.AddCables();
            repo.AddRoutes();
        }
    }
}
