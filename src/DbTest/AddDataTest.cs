using ElectricalEntityLib;
using ElectricalEntityLib.Entity;
using Xunit.Extensions.Ordering;

namespace DbTest
{
    [Order(1)]
    public class AddDataTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _dbFixture;

        public AddDataTest(DatabaseFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }

        [Fact, Order(2)]
        public void AddConductorSize()
        {
            _dbFixture.Repo.AddConductorSizes();
            var sizes = _dbFixture.Repo.GetConductorSizes();
            Assert.True(sizes?.Children?.Count() > 0);
        }

        [Fact, Order(2)]
        public void AddSegSystems()
        {
            _dbFixture.Repo.AddSegSystems();
            Assert.True(_dbFixture.DbContext.SegSystems.Count() > 0);
        }

        [Fact, Order(2)]
        public void AddTraySpecs()
        {
            _dbFixture.Repo.AddTraySpecs();
            Assert.True(_dbFixture.DbContext.TraySpecs.Count() > 0);
        }

        [Fact, Order(2)]
        public void AddNodes()
        {
            _dbFixture.Repo.AddNodes();
            Assert.True(_dbFixture.DbContext.Nodes.Count() > 0);
        }

        [Fact, Order(2)]
        public void AddLoads()
        {
            _dbFixture.Repo.AddLoads();
            Assert.True(_dbFixture.DbContext.Loads.Count() > 0);
        }

        [Fact, Order(3)]
        public void AddCableSpecs()
        {
            _dbFixture.Repo.AddCableSpecs();
            Assert.True(_dbFixture.DbContext.CableSpecs.Count() > 0);
        }

        [Fact, Order(3)]
        public void AddRaceways()
        {
            _dbFixture.Repo.AddRaceways();
            Assert.True(_dbFixture.DbContext.Raceways.Count() > 0);
        }

        [Fact, Order(4)]
        public void AddCable()
        {
            _dbFixture.Repo.AddCables();
            var cables = _dbFixture.Repo.GetCables();
            var c = cables.First();
            var cs = c.CableSpec!;
            Assert.Equal(2, cables.Count());
            Assert.Equal(TestRepo.CZ4_0, cs.Name);
            Assert.Equal(ServiceEnum.Power, c.ServiceType);
            Assert.Equal(TestRepo.CZ4_0, cs.ConductorSize?.Value);
        }

        [Fact, Order(5)]
        public void AddRoute()
        {
            _dbFixture.Repo.AddRoutes();
            var rt = _dbFixture.Repo.GetRoute();
            Assert.NotNull(rt);
            Assert.True(rt?.Path.Count() > 0);

            var cbl = _dbFixture.Repo.GetCableWithRoute(rt?.Cable?.Name!);
            Assert.NotNull(cbl);
            Assert.True(cbl?.Route?.Path.Count() > 0);
        }
    }
}