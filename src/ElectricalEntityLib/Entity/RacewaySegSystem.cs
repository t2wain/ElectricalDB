using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricalEntityLib.Entity
{
    [PrimaryKey(nameof(RacewayId), nameof(SegSystemId))]
    public class RacewaySegSystem
    {
        public int RacewayId { get; set; }
        public Raceway? Raceway { get; set; }
        public int SegSystemId { get; set; }
        public SegSystem? SegSystem { get; set; }
    }
}
