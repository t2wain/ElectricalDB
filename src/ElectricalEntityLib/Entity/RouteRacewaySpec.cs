using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(RouteSpecId), nameof(RacewayId), IsUnique = true)]
    public class RouteRacewaySpec
    {
        public int Id { get; set; }
        public int RouteSpecId { get; set; }
        public RouteSpec? RouteSpec { get; set; }
        public int RacewayId { get; set; }
        public Raceway? Raceway { get; set; }
        public double Sequence { get; set; }
        public int RacewayMode { get; set; }
    }
}
