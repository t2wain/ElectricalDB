using ElectricalDbSqliteLib;
using ElectricalEntityLib;

using var db = ElectricalDbContext.MemoryDbContext;
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
