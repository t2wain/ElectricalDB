using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    public class Route
    {
        public int Id { get; set; }
        public int CableId { get; set; }
        public Cable? Cable { get; set; }
        public int? RouteSpecId { get; set; }
        public RouteSpec? RouteSpec { get; set; }
        public IEnumerable<RoutePath> Path { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public int? DesignStatus { get; set; }
        public string? VersionNo { get; set; }
    }
}
