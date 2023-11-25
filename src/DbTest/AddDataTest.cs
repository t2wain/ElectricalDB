using ElectricalDbSqliteLib;
using ElectricalEntityLib;
using ElectricalEntityLib.Entity;

namespace DbTest
{
    public class AddDataTest
    {
        TestRepo _repo;

        public AddDataTest()
        {
            _repo = new TestRepo(ElectricalDbContext.MemoryDbContext);
            _repo.AddConductorSizes();
            _repo.AddSegSystems();
            _repo.AddTraySpecs();
            _repo.AddCableSpecs();

            _repo.AddNodes();
            _repo.AddCables();
            _repo.AddRaceways();
        }

        [Fact]
        public void AddCable()
        {
            var cables = _repo.GetCables();
            var c = cables.First();
            var cs = c.CableSpec!;
            Assert.Equal(2, cables.Count());
            Assert.Equal(TestRepo.CZ4_0, cs.Name);
            Assert.Equal(ServiceEnum.Power, c.ServiceType);
            Assert.Equal(TestRepo.CZ4_0, cs.ConductorSize?.Value);
        }

        [Fact]
        public void AddConductorSize()
        {
            var sizes = _repo.GetConductorSizes();
            Assert.True(sizes?.Children?.Count() > 0);
        }
    }
}