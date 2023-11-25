using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ElectricalEntityLib.Entity
{
    [Index(nameof(Name), IsUnique = true)]
    public class RouteSpec
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int FromNodeId { get; set; }
        public Node? FromNode { get; set; }
        [Required]
        public int ToNodeId { get; set; }
        public Node? ToNode { get; set; }
        [Required]
        public int SegSystemId { get; set; }
        public SegSystem? SegSystem { get; set; }
        public IEnumerable<RouteRacewaySpec>? RouteRacewaySpecs { get; set; }
    }
}
