using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(RouteId), nameof(RacewayId), IsUnique = true)]
    public class RoutePath
    {
        public int Id { get; set; }
        [Required]
        public int RouteId { get; set; }
        [Required]
        public int RacewayId { get; set; }
        public Raceway? Raceway { get; set; }
        public double Sequence { get; set; }
    }
}
