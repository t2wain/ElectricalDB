using ElectricalEntityLib;
using Microsoft.EntityFrameworkCore;

namespace ElectricalDbJetLib
{
    public class ElectricalDbContextJet : ElectricalDbContextBase
    {
        public ElectricalDbContextJet(DbContextOptions<ElectricalDbContextJet> options) : base(options)
        {

        }
    }
}