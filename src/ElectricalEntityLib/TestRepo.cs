using ElectricalEntityLib.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElectricalEntityLib
{
    public class TestRepo
    {
        public const string CZ1_0 = "1/0awg";
        public const string CZ4_0 = "4/0awg";
        public const string CZ250 = "250kcmil";
        public const string CZ900 = "900kcmil";
        public const string CZ1000 = "1000kcmil";
        public const string LADDER = "LADDER";

        ElectricalDbContextBase _dbCtx = null;

        public TestRepo(ElectricalDbContextBase dbCtx)
        {
            _dbCtx = dbCtx;
        }

        #region Library Setup

        public void AddConductorSizes()
        {
            //var cs = this.GetConductorSizes();
            //if (cs != null)
            //    return;

            string[] NecConductorSizes = new string[]
            {
                "22awg", "20awg", "18awg", "16awg", "14awg",
                "12awg", "10awg", "8awg", "6awg", "4awg", "2awg", "1awg",
                CZ1_0, "2/0awg", "3/0awg", CZ4_0,
                CZ250, "300kcmil", "350kcmil", "400kcmil",
                "500kcmil", "600kcmil", "700kcmil", "750kcmil",
                "800kcmil", CZ900, CZ1000, "1250kcmil",
                "1500kcmil", "1750kcmil", "2000kcmil"
            };

            var (Size, _) = NecConductorSizes
                .Aggregate((Size: new Dictionary<string, int>(), Idx: 1), (agg, s) =>
                {
                    agg.Size[s] = agg.Idx;
                    // assign index based on relative conductor size
                    return (agg.Size, agg.Idx + 1);
                });

            Size.Select(kv => new LookUp { Value = kv.Key, Value2 = kv.Value });

            var sizes = new LookUp
            {
                Value = "NEC Conductor Sizes",
                Value2 = 100,
                Children = Size.Select(kv => new LookUp { Value = kv.Key, Value2 = kv.Value * 10 }).ToList()
            };
            _dbCtx.Add(sizes);
            _dbCtx.SaveChanges();
        }

        public void AddCableSpecs()
        {
            var sizes = this.GetConductorSizes()?.Children?.ToDictionary(lk => lk.Value)!;

            // cable library headers
            var necLib1 = new LookUp { Value = "3/C, 600V, Power" };
            var necLib2 = new LookUp { Value = "1/C, 600V, Grounding" };
            var necLib3 = new LookUp { Value = "3/C, 5 kV, Power" };
            var necLib4 = new LookUp { Value = "1/C, 5 kV, Power" };
            var necLib5 = new LookUp { Value = "1/C, 15 kV, Power" };
            var necLib6 = new LookUp { Value = "Instrument" };
            var necLib7 = new LookUp { Value = "Control" };

            var cslib = new LookUp
            {
                Value = "Cable Spec Library",
                Value2 = 200,
                Children = new List<LookUp> 
                { 
                    necLib1, necLib2, necLib3, 
                    necLib4, necLib5, necLib6, necLib7 
                }
            };

            _dbCtx.AddRange(cslib);

            // group cable specs into libraries
            var cspecs = new List<CableSpec>
            {
                #region 3/C, 600V, NEC Cable Spec

                new() { Name = "12awg", ConductorSize = sizes["12awg"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 2.0 / 1000.0, XUnitLength = 0.054 / 1000.0, Ampacity = 25 },

                new() { Name = "10awg", ConductorSize = sizes["10awg"], CableLibrary = necLib1, 
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power, 
                    RUnitLength = 1.2 / 1000.0, XUnitLength = 0.05 / 1000.0, Ampacity = 35 },

                new() { Name = "8awg", ConductorSize = sizes["8awg"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.78 / 1000.0, XUnitLength = 0.052 / 1000.0, Ampacity = 50 },

                new() { Name = "6awg", ConductorSize = sizes["6awg"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.49 / 1000.0, XUnitLength = 0.051 / 1000.0, Ampacity = 65 },

                new() { Name = "4awg", ConductorSize = sizes["4awg"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.31 / 1000.0, XUnitLength = 0.048 / 1000.0, Ampacity = 85 },

                new() { Name = "2awg", ConductorSize = sizes["2awg"], CableLibrary = necLib1, 
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power ,
                    RUnitLength = 0.2 / 1000.0, XUnitLength = 0.046 / 1000.0, Ampacity = 130 },

                new() { Name = "1awg", ConductorSize = sizes["1awg"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.16 / 1000.0, XUnitLength = 0.048 / 1000.0, Ampacity = 85 },

                new() { Name = CZ1_0, ConductorSize = sizes[CZ1_0], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.13 / 1000.0, XUnitLength = 0.044 / 1000.0, Ampacity = 150 },

                new() { Name = "2/0awg", ConductorSize = sizes["2/0awg"], CableLibrary = necLib1, 
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.1 / 1000.0, XUnitLength = 0.043 / 1000.0, Ampacity = 175 },

                new() { Name = CZ4_0, ConductorSize = sizes[CZ4_0], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.067 / 1000.0, XUnitLength = 0.041 / 1000.0, Ampacity = 230 },

                new() { Name = CZ250, ConductorSize = sizes[CZ250], CableLibrary = necLib1, 
                    InsulationVoltage = 600, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.057 / 1000.0, XUnitLength = 0.041 / 1000.0, Ampacity = 255 },

                new() { Name = "350kcmil", ConductorSize = sizes["350kcmil"], CableLibrary = necLib1,
                    InsulationVoltage = 600, OutsideDiameter = 2.270, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.043 / 1000.0, XUnitLength = 0.040 / 1000.0, Ampacity = 310 },

                new() { Name = "500kcmil", ConductorSize = sizes["500kcmil"], CableLibrary = necLib1, 
                    InsulationVoltage = 600, OutsideDiameter = 2.270, ServiceType = ServiceEnum.Power,
                    RUnitLength = 0.067 / 1000.0, XUnitLength = 0.041 / 1000.0, Ampacity = 230 },

                #endregion

                #region 1/C, 600V, Grounding

                new() { Name = "GL01N4-0", ConductorSize = sizes[CZ4_0], IsSingleConductor = true, CableLibrary = necLib2,
                    InsulationVoltage = 600, OutsideDiameter = 0.619, ServiceType = ServiceEnum.Grounding },

                new() { Name = "GL01N250", ConductorSize = sizes[CZ250], IsSingleConductor = true, CableLibrary = necLib2, 
                    InsulationVoltage = 600, OutsideDiameter = 0.702, ServiceType = ServiceEnum.Grounding },

                #endregion

                #region 3/C, 5 kV, Power

                new() { Name = "PM03A002", ConductorSize = sizes["2awg"], CableLibrary = necLib3,
                    InsulationVoltage = 5000, OutsideDiameter = 1.79, ServiceType = ServiceEnum.Power  },

                new() { Name = "PM03A2-0", ConductorSize = sizes["2/0awg"], CableLibrary = necLib3, 
                    InsulationVoltage = 5000, OutsideDiameter = 2.16, ServiceType = ServiceEnum.Power  },

                new() { Name = CZ250, ConductorSize = sizes[CZ250], CableLibrary = necLib3, 
                    InsulationVoltage = 5000, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power  },

                new() { Name = "PM03A500", ConductorSize = sizes["500kcmil"], CableLibrary = necLib3, 
                    InsulationVoltage = 5000, OutsideDiameter = 3.15, ServiceType = ServiceEnum.Power  },

                new() { Name = CZ1000, ConductorSize = sizes[CZ1000], CableLibrary = necLib3, 
                    InsulationVoltage = 5000, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power  },

                #endregion

                #region 1/C, 5 kV, Power

                new() { Name = "1x250kcmil", ConductorSize = sizes[CZ250], IsSingleConductor = true, CableLibrary = necLib4,
                    InsulationVoltage = 5000, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power  },

                new() { Name = "1x500kcmil", ConductorSize = sizes["500kcmil"], IsSingleConductor = true, CableLibrary = necLib4, 
                    InsulationVoltage = 5000, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Power  },

                #endregion

                #region 1/C, 15 kV, Power

                new() { Name = "PD01N750", ConductorSize = sizes["750kcmil"], IsSingleConductor = true, CableLibrary = necLib5,
                    InsulationVoltage = 15000, OutsideDiameter = 1.665, ServiceType = ServiceEnum.Power  },

                #endregion

                #region Instrument

                new() { Name = "22awg", ConductorSize = sizes["22awg"], CableLibrary = necLib6,
                    InsulationVoltage = 300, OutsideDiameter = 0.1, ServiceType = ServiceEnum.Instrument },

                new() { Name = "IP16N016", ConductorSize = sizes["16awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 1.23, ServiceType = ServiceEnum.Instrument },

                new() { Name = "OT01N016", ConductorSize = sizes["16awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.303, ServiceType = ServiceEnum.Instrument },

                new() { Name = "IP01N018", ConductorSize = sizes["18awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.3, ServiceType = ServiceEnum.Instrument },

                new() { Name = "IP06N018", ConductorSize = sizes["18awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.69, ServiceType = ServiceEnum.Instrument },

                new() { Name = "IT06N018", ConductorSize = sizes["18awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.82, ServiceType = ServiceEnum.Instrument },

                #endregion

                #region Control

                new() { Name = "CL04N010", ConductorSize = sizes["10awg"], CableLibrary = necLib7,
                    InsulationVoltage = 600, OutsideDiameter = 0.56, ServiceType = ServiceEnum.Control },

                new() { Name = "CL04N012", ConductorSize = sizes["12awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.47, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL02N012", ConductorSize = sizes["12awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.44, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL02N014", ConductorSize = sizes["14awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.37, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL04N014", ConductorSize = sizes["14awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.43, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL04N016", ConductorSize = sizes["16awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.33, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL06N016", ConductorSize = sizes["16awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.438, ServiceType =  ServiceEnum.Control },

                new() { Name = "CL08N016", ConductorSize = sizes["16awg"], 
                    InsulationVoltage = 600, OutsideDiameter = 0.447, ServiceType =  ServiceEnum.Control },

                #endregion
            };

            _dbCtx.AddRange(cspecs);
            _dbCtx.SaveChanges();
        }

        public void AddSegSystems()
        {
            var ss = new SegSystem[] {
                new() { Name = "LV" },
                new() { Name = "CV" },
                new() { Name = "MV" },
                new() { Name = "HV" },
                new() { Name = "IN" },
            };

            _dbCtx.AddRange(ss);
            _dbCtx.SaveChanges();
        }

        public void AddTraySpecs()
        {
            var tspecs = new List<TraySpec>
            {
                new() { Name = "36", BottomType = LADDER, Width = 36, Depth = 6 },
                new() { Name = "30", BottomType = LADDER, Width = 30, Depth = 6 },
                new() { Name = "24", BottomType = LADDER, Width = 24, Depth = 6 },
                new() { Name = "12", BottomType = LADDER, Width = 12, Depth = 6 },
                new() { Name = "6", BottomType = LADDER, Width = 6, Depth = 6 },
            };

            _dbCtx.AddRange(tspecs);
            _dbCtx.SaveChanges();
        }

        #endregion

        #region Project Data

        public void AddNodes()
        {
            var nodeIds = new string[]
            {
                "N1", "N2", "N3", "N4", "N5", "N6",
                "N7A", "N7B", "N8", "N9", "N10",
                "E1", "E2", "E3", "E4"
            };

            var nodes = nodeIds.Select(id => new Node { Name = id }).ToDictionary(n => n.Name);

            _dbCtx.AddRange(nodes.Values);
            _dbCtx.SaveChanges();
        }

        public void AddCables()
        {
            var nodes = _dbCtx.Nodes.ToDictionary(n => n.Name);
            var ss = _dbCtx.SegSystems.Where(ss => ss.Name == "LV").First();
            var cspec = _dbCtx.CableSpecs
                .Where(cs => cs.CableLibrary!.Value == "3/C, 600V, Power" && cs.Name == CZ4_0)
                .First();

            var cables = new Cable[]
            {
                new() { Name = "CABLE1", CableSpec = cspec, FromNode = nodes["E1"], ToNode = nodes["E2"],
                    SegSystem = ss, ServiceType = ServiceEnum.Power },

                new() { Name = "CABLE2", CableSpec = cspec, FromNode = nodes["E3"], ToNode = nodes["E4"],
                    SegSystem = ss, ServiceType = ServiceEnum.Power }
             };

            _dbCtx.AddRange(cables);
            _dbCtx.SaveChanges();
        }

        public void AddRaceways()
        {
            var ss = _dbCtx.SegSystems.ToList();
            var nodes = _dbCtx.Nodes.ToDictionary(n => n.Name);
            var ts = _dbCtx.TraySpecs.ToDictionary(ts => ts.Name);

            var raceways = new List<Raceway>()
            {
                new() { Name = "R1", FromNode = nodes["N1"], ToNode = nodes["N2"], TraySpec = ts["36"] },
                new() { Name = "R2", FromNode = nodes["N2"], ToNode = nodes["N3"], TraySpec = ts["36"] },

                // parallel edges
                new() { Name = "R3A", FromNode = nodes["N3"], ToNode = nodes["N4"], TraySpec = ts["36"] },
                new() { Name = "R3B", FromNode = nodes["N3"], ToNode = nodes["N4"], TraySpec = ts["36"], Length = 2.0 },

                new() { Name = "R4", FromNode = nodes["N4"], ToNode = nodes["N5"], TraySpec = ts["36"] },
                new() { Name = "R5", FromNode = nodes["N5"], ToNode = nodes["N6"], TraySpec = ts["36"] },

                // parallel R6 and R7
                new() { Name = "R6A", FromNode = nodes["N6"], ToNode = nodes["N7A"], TraySpec = ts["36"] },
                new() { Name = "R6A1", FromNode = nodes["N6"], ToNode = nodes["N7A"], TraySpec = ts["36"], Length = 2.0 },
                new() { Name = "R7A", FromNode = nodes["N7A"], ToNode = nodes["N8"], TraySpec = ts["36"] },
                new() { Name = "R6B", FromNode = nodes["N6"], ToNode = nodes["N7B"], TraySpec = ts["36"], Length = 2.0 },
                new() { Name = "R7B", FromNode = nodes["N7B"], ToNode = nodes["N8"], TraySpec = ts["36"], Length = 2.0 },

                new() { Name = "R8", FromNode = nodes["N8"], ToNode = nodes["N9"], TraySpec = ts["36"] },
                new() { Name = "R9", FromNode = nodes["N9"], ToNode = nodes["N10"], TraySpec = ts["36"] },

                new() { Name = "J1", FromNode = nodes["N7A"], ToNode = nodes["N7B"], RacewayType = RacewayEnum.Drop },

                new() { Name = "D1", FromNode = nodes["E1"], ToNode = nodes["N1"], RacewayType = RacewayEnum.Drop },
                new() { Name = "D2", FromNode = nodes["E2"], ToNode = nodes["N7A"], RacewayType = RacewayEnum.Drop },
                new() { Name = "D3", FromNode = nodes["E3"], ToNode = nodes["N7B"], RacewayType = RacewayEnum.Drop },
                new() { Name = "D4", FromNode = nodes["E4"], ToNode = nodes["N10"], RacewayType = RacewayEnum.Drop },
            };

            foreach (var rw in raceways)
                rw.SegSystems = ss.Select(sg => new RacewaySegSystem { Raceway = rw, SegSystem = sg }).ToList();

            _dbCtx.AddRange(raceways);
            _dbCtx.SaveChanges();
        }

        public void AddRoute()
        {
            var cbl = _dbCtx.Cables.Where(c => c.Name == "CABLE1").First();
            var rw = _dbCtx.Raceways.ToDictionary(r => r.Name);
            var nodes = _dbCtx.Nodes.ToDictionary(n => n.Name);
            var ss = _dbCtx.SegSystems.ToDictionary(s => s.Name);
            var rs = new RouteSpec { Name = cbl.Name, FromNode = nodes["E1"], ToNode = nodes["E2"], SegSystem = ss["LV"] };
            var rt = new Route
            {
                Cable = cbl,
                RouteSpec = rs,
                DateCreated = DateTime.Now,
                Path = new List<RoutePath> 
                { 
                    new() { Raceway = rw["D1"], Sequence = 1 },
                    new() { Raceway = rw["R1"], Sequence = 2 },
                    new() { Raceway = rw["R2"], Sequence = 3 },
                    new() { Raceway = rw["R3A"], Sequence = 4 },
                    new() { Raceway = rw["R4"], Sequence = 5 },
                    new() { Raceway = rw["R6A"], Sequence = 6 },
                    new() { Raceway = rw["D2"], Sequence = 7 },
                }
            };

            cbl.Route = rt;
            cbl.RouteSpec = rs;

            _dbCtx.CableFills.AddRange(
                rt.Path.Select(p => new CableFill { Cable = cbl, Raceway = p.Raceway }).ToList());

            _dbCtx.SaveChanges();
        }

        #endregion

        #region Queries

        public LookUp? GetConductorSizes() =>
            _dbCtx.LookUps
                .Include(lk => lk.Children)
                .Where(lk => lk.ParentId == null && lk.Value2 == 100)
                .FirstOrDefault();

        public IEnumerable<CableSpec> GetCableSpecs() =>
            _dbCtx.CableSpecs
                .Include(cs => cs.ConductorSize)
                .Include(cs => cs.CableLibrary)
                .ToList();

        public IEnumerable<Cable> GetCables() => 
            _dbCtx.Cables
                .Include(c => c.CableSpec!).ThenInclude(cs => cs.ConductorSize)
                .Include(c => c.FromNode)
                .Include(c => c.ToNode)
                .Include(c => c.SegSystem)
                .ToList();

        public IEnumerable<Raceway> GetRaceways() =>
            _dbCtx.Raceways
                .Include(r => r.FromNode)
                .Include(r => r.ToNode)
                .Include(r => r.TraySpec)
                .Include(r => r.SegSystems!).ThenInclude(ss => ss.SegSystem)
                .ToList();

        public Route? GetRoute() =>
            _dbCtx.Routes.Include(rt => rt.Cable).Include(rt => rt.Path)
            .Join(_dbCtx.Cables, rt => rt.Id, cbl => cbl.RouteId, (rt, cbl) => rt)
            .FirstOrDefault();

        public Cable? GetCableWithRoute(string cableName) =>
            _dbCtx.Cables
                .Include(cbl => cbl.Route)
                .ThenInclude(rt => rt!.Path)
                .ThenInclude(p => p.Raceway)
                .Where(cbl => cbl.Name == "CABLE1")
                .FirstOrDefault();
            

        #endregion
    }
}
